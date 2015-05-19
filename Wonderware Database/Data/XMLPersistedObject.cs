using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Reflection;
using System.Diagnostics;

namespace Wonderware.Data
{
	public class XMLPersistedObject
	{

		public XMLPersistedObject()
		{
			TextContent = String.Empty;
			Parent = null;
		}

		static XMLPersistedObject()
		{
			m_XMLReaderSettings = new XmlReaderSettings();
			m_XMLReaderSettings.DtdProcessing = DtdProcessing.Ignore;
			//m_XMLReaderSettings.Async = false;
			m_XMLReaderSettings.IgnoreWhitespace = true;
			m_XMLReaderSettings.IgnoreComments = true;
		}

		public XMLPersistedObject Parent;
		private static XmlReaderSettings m_XMLReaderSettings;
		public string TextContent;

		public void LoadFileAsync(FileInfo p_XMLFileInfo, String p_sXMLRootElement)
		{
			FileStream l_RootElementFileStream = null;
			XmlReader l_RootElementXMLReader = null;
			try
			{
				l_RootElementFileStream = File.OpenRead(p_XMLFileInfo.FullName);
				l_RootElementXMLReader = XmlReader.Create(l_RootElementFileStream, m_XMLReaderSettings);
				while (l_RootElementXMLReader.Read())
				{
					if (l_RootElementXMLReader.Name == p_sXMLRootElement)
					{
						LoadRootXMLAsync(l_RootElementXMLReader, p_sXMLRootElement, null);
						break;
					}
				}
				// If root element not found raise error
			}
			catch (Exception ex)
			{
				ReportXMLReadError("COULD NOT LOAD XML '" + p_XMLFileInfo.FullName + "'-> Unkown Exception : " + ex.Message);
			}
			finally
			{
				if (l_RootElementXMLReader != null)
				{
					l_RootElementXMLReader.Close();
					//l_RootElementXMLReader.Dispose();
					l_RootElementXMLReader = null;
				}
				if (l_RootElementFileStream != null)
				{
					l_RootElementFileStream.Close();
					//l_RootElementFileStream.Dispose();
					l_RootElementFileStream = null;
				}
			}
		}

		public void ParseAttribute(String p_sName, String p_sValue)
		{
			Type l_ThisType = this.GetType();

			FieldInfo l_FieldInfo = l_ThisType.GetField(p_sName);
			if (l_FieldInfo != null)
			{
				Object[] l_CustomAttributes = l_FieldInfo.GetCustomAttributes(typeof(AttributeIsXMLAttribute), true) ;
				if (l_CustomAttributes.Length > 0)
				{
					AttributeIsXMLAttribute l_AttributeIsXMLAttribute = l_CustomAttributes[0] as AttributeIsXMLAttribute;
					Type l_FieldType = l_FieldInfo.FieldType;
					switch (l_FieldType.Name)
					{
						case "Int16":
						case "Int32":
						case "Int64":
							if (p_sValue == String.Empty)
							{
								l_FieldInfo.SetValue(this, 0);
							}
							else
							{
								l_FieldInfo.SetValue(this, System.Convert.ToInt32(p_sValue));
							}
							break;
						case "Double":
							l_FieldInfo.SetValue(this, System.Convert.ToDouble(p_sValue));
							break;
						case "Single":
							l_FieldInfo.SetValue(this, System.Convert.ToSingle(p_sValue));
							break;
						case "String":
							l_FieldInfo.SetValue(this, p_sValue);
							break;
						case "Boolean":
							l_FieldInfo.SetValue(this, System.Convert.ToBoolean(p_sValue));
							break;
						default:
							ReportXMLReadError("Unsopported FieldType : " + l_FieldType.Name + " : for attribute : " + p_sName + " : Type = " + l_ThisType.ToString());
							break;
					}
				}
				else
				{
					ReportXMLReadError("Unsopported attribute : " + p_sName + " : Type = " + l_ThisType.ToString() + " : Field found but not marked as AttributeIsXMLAttribute");
				}
			}
			else
			{
				ReportXMLReadError("Unsopported attribute : " + p_sName + " : Type = " + l_ThisType.ToString());
			}
		}

		public void ParseSubProperty(String p_sName, String p_sValue)
		{
			String l_sTransformedName = TransformReservedWords(p_sName);

			Type l_ThisType = this.GetType();

			FieldInfo l_FieldInfo = l_ThisType.GetField(l_sTransformedName);
			if (l_FieldInfo != null)
			{
				Object[] l_CustomAttributes = l_FieldInfo.GetCustomAttributes(typeof(AttributeIsXMLSubProperty), true) ;
				if (l_CustomAttributes.Length > 0)
				{
					AttributeIsXMLSubProperty l_AttributeIsXMLSubProperty = l_CustomAttributes[0] as AttributeIsXMLSubProperty;

					Type l_FieldType = l_FieldInfo.FieldType;
					switch (l_FieldType.Name)
					{
						case "Int16":
						case "Int32":
						case "Int64":
							if (p_sValue == String.Empty)
							{
								l_FieldInfo.SetValue(this, 0);
							}
							else
							{
								l_FieldInfo.SetValue(this, System.Convert.ToInt32(p_sValue));
							}
							break;
						case "Double":
							l_FieldInfo.SetValue(this, System.Convert.ToDouble(p_sValue));
							break;
						case "String":
							l_FieldInfo.SetValue(this, p_sValue);
							break;
						case "Boolean":
							l_FieldInfo.SetValue(this, System.Convert.ToBoolean(p_sValue));
							break;
						default:
							ReportXMLReadError("Unsopported FieldType : " + l_FieldType.Name + " : for sub property : " + p_sName + " : Type = " + l_ThisType.ToString());
							break;
					}
				}
				else
				{
					ReportXMLReadError("Unsopported sub property : " + p_sName + " : Type = " + l_ThisType.ToString() + " : Field found but not marked as AttributeIsXMLAttribute");
				}
			}
			else
			{
				ReportXMLReadError("Unsopported sub property : " + p_sName + " : Type = " + l_ThisType.ToString());
			}
		}

		private String TransformReservedWords(String l_sPotentialReservedWord)
		{
			switch (l_sPotentialReservedWord)
			{
				case "default":
					return "Default";
				default:
					return l_sPotentialReservedWord;
			}
		}

		public virtual XMLPersistedObject GetSubElementObject(String p_sName)
		{
			switch (p_sName)
			{
				case "TEXT":
					return new wwText();
				case "RECTANGLE":
					return new wwRectangle();
				case "ROUNDRECTANGLE":
					return new wwRoundRectangle();
				case "POLYGON":
					return new wwPolygon();
				case "POLYLINE":
					return new wwPolyline();
				case "LINE":
					return new wwLine();
				case "ELLIPSE":
					return new wwEllipse();
				case "BUTTON":
					return new wwButton();
				case "SYMBOLS":
					return new wwGraphicSet();
				default:
					return null;
			}
		}

		public virtual void AddSubElementObject(XMLPersistedObject l_SubElementObject)
		{
		}

		public bool IsSubProperty(String p_sName)
		{
			String l_sTransformedName = TransformReservedWords(p_sName);

			Type l_ThisType = this.GetType();

			FieldInfo l_FieldInfo = l_ThisType.GetField(l_sTransformedName);
			if (l_FieldInfo != null)
			{
				Object[] l_CustomAttributes = l_FieldInfo.GetCustomAttributes(typeof(AttributeIsXMLSubProperty), true) ;
				if (l_CustomAttributes.Length > 0)
				{
					return true;
				}
				else
				{
					ReportXMLReadError("Unsopported sub property : " + p_sName + " : Type = " + l_ThisType.ToString() + " : Field found but not marked as AttributeIsXMLAttribute");
					return false;
				}
			}
			else
			{
				return false;
			}
		}

		public virtual bool IsSubElement(String p_sName)
		{
			switch (p_sName)
			{
				case "LINE":
				case "TEXT":
				case "BUTTON":
				case "ELLIPSE":
				case "POLYGON":
				case "POLYLINE":
				case "RECTANGLE":
				case "ROUNDRECTANGLE":
				case "REALTIME_TREND":
					return true;
				default:
					return false;
			}
		}

		public void ReportXMLReadError(String p_sMessage)
		{
			Debug.WriteLine(p_sMessage, "ERROR XML READ");
		}

		private void LoadSubElementAsync(XmlReader p_RootElementXMLReader)
		{
			String l_sTextContent = null;
			String l_sElementName = p_RootElementXMLReader.Name;

			if (IsSubElement(l_sElementName) == true)
			{
				XMLPersistedObject l_SubElementObject = GetSubElementObject(l_sElementName);
				if (l_SubElementObject != null)
				{
					l_SubElementObject.LoadRootXMLAsync(p_RootElementXMLReader, l_sElementName, this);
					AddSubElementObject(l_SubElementObject);
				}
				else
				{
					ReportXMLReadError("Sub element object not parsed because no object provided : " + l_sElementName);
					while (p_RootElementXMLReader.Read())
					{
						if (IsEndOfElement(p_RootElementXMLReader, l_sElementName))
						{
							break;
						}
					}
				}
			}
			else if (IsSubProperty(l_sElementName) == true)
			{
				if (p_RootElementXMLReader.HasAttributes)
				{
					ReportXMLReadError("Sub property contains attributes : " + l_sElementName);
				}
				if (p_RootElementXMLReader.IsEmptyElement == false)
				{
					p_RootElementXMLReader.Read();
					if (p_RootElementXMLReader.NodeType == XmlNodeType.Text)
					{
						l_sTextContent = p_RootElementXMLReader.Value;
						ParseSubProperty(l_sElementName, l_sTextContent);
						p_RootElementXMLReader.Read();
					}
					else if (p_RootElementXMLReader.NodeType == XmlNodeType.CDATA)
					{
						l_sTextContent = p_RootElementXMLReader.Value;
						ParseSubProperty(l_sElementName, l_sTextContent);
						p_RootElementXMLReader.Read();
					}
					if (IsEndOfElement(p_RootElementXMLReader, l_sElementName) == false)
					{
						ReportXMLReadError("Sub property not parsed correctly : " + l_sElementName);
						while (p_RootElementXMLReader.Read())
						{
							if (IsEndOfElement(p_RootElementXMLReader, l_sElementName))
							{
								break;
							}
						}
					}
				}
			}
			else
			{
				ReportXMLReadError("Unsupported sub element : " + l_sElementName);
				while (p_RootElementXMLReader.Read())
				{
					if (IsEndOfElement(p_RootElementXMLReader, l_sElementName))
					{
						break;
					}
				}
			}
		}

		private bool IsEndOfElement(XmlReader p_RootElementXMLReader, String p_sElementName)
		{
			return (p_RootElementXMLReader.NodeType == XmlNodeType.EndElement && p_RootElementXMLReader.Name == p_sElementName);
		}

		public void LoadRootXMLAsync(XmlReader p_RootElementXMLReader, String p_sElementName, XMLPersistedObject p_ParentObject)
		{
			Parent = p_ParentObject;
			TextContent = String.Empty;

			// Root element
			if (p_RootElementXMLReader.Name == p_sElementName)
			{
				// Attributes
				if (p_RootElementXMLReader.HasAttributes)
				{
					while (p_RootElementXMLReader.MoveToNextAttribute())
					{
						ParseAttribute(p_RootElementXMLReader.Name, p_RootElementXMLReader.Value);
					}
					p_RootElementXMLReader.MoveToElement();
				}

				if (p_RootElementXMLReader.IsEmptyElement == false)
				{
					// Sub Elements
					while (p_RootElementXMLReader.Read())
					{
						if (p_RootElementXMLReader.NodeType == XmlNodeType.EndElement &&
							p_RootElementXMLReader.Name == p_sElementName)
						{
							break; // < End of Root Element, e.g. parsing done
						}

						switch (p_RootElementXMLReader.NodeType)
						{
							case XmlNodeType.Element:
								LoadSubElementAsync(p_RootElementXMLReader);
								break;
							case XmlNodeType.Text:
								TextContent += p_RootElementXMLReader.Value;
								break;
							case XmlNodeType.EndElement:
								if (p_RootElementXMLReader.Name != p_sElementName)
								{
									ReportXMLReadError("Matching end element not found for root element <" + p_sElementName + ">");
								}
								break;
							default:
								ReportXMLReadError("Unsupported node type");
								break;
						}
					}
				}
			}
			else
			{
				ReportXMLReadError("The root element must be <" + p_sElementName + ">");
			}
		}

	}
}
