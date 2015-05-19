using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using System.Windows.Forms;
using System.Diagnostics;
using Wonderware.Management;

namespace Wonderware.Data
{
	public class HMIDiagram : GraphicObject
	{
		public HMIDiagram()
		{
			APPPATH			= String.Empty;
			DATECREATED		= String.Empty;
			BGCOLOR			= String.Empty;
			GraphicObjects	= new List<GraphicObject>();
		}

		public FileInfo NodeXmlFile;
		public FileInfo IcDiagramXmlFile;
		public FileInfo GraphicCivlFile;

		// Attributes
		[AttributeIsXMLAttribute()]
		public String APPPATH;
		[AttributeIsXMLAttribute()]
		public String DATECREATED;

		// Properties

		// Sub Elements
		public List<GraphicObject> GraphicObjects;

		public override bool IsSubElement(String p_sName)
		{
			switch (p_sName)
			{
				case "XML":
				case "FILL":
				case "LINE":
				case "TEXT":
				case "SYMBOL":
				case "BUTTON":
				case "EVENTS":
				case "ELLIPSE":
				case "POLYGON":
				case "VISIBLE":
				case "POLYLINE":
				case "RECTANGLE":
				case "BEHAVIORS":
				case "EXPRESSION":
				case "SCRIPTTAGS":
				case "MAPDISCRETE":
				case "ROUNDRECTANGLE":
				case "REALTIME_TREND":
				case "THRESHOLDANALOG":
					return true;
				default:
					return base.IsSubElement(p_sName);
			}
		}

		public override XMLPersistedObject GetSubElementObject(String p_sName)
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
				case "SYMBOL":
					return new HMIDiagram();
				case "VISIBLE":
					return new wwVisibility();
				case "FILL":
					return new wwFillColor();
				case "BEHAVIORS":
					return new wwBehaviors();
				default:
					return base.GetSubElementObject(p_sName);
			}
		}

		public override void AddSubElementObject(XMLPersistedObject p_SubElementObject)
		{
			base.AddSubElementObject(p_SubElementObject);
			GraphicObject l_GraphicObject = p_SubElementObject as GraphicObject;
			if (l_GraphicObject != null)
			{
				GraphicObjects.Add(l_GraphicObject);
			}
		}

		//
		// Methods
		//
		
		public void Visibility(bool visible)
		{
			foreach (GraphicObject l_GraphicObject in GraphicObjects)
			{
			}
		}

		public override void SyncData(Database p_Database)
		{
			foreach (GraphicObject l_GraphicObject in GraphicObjects)
			{
				l_GraphicObject.SyncData(p_Database);
			}
		}

		public override void SyncGraphics(Database p_Database)
		{
			foreach (GraphicObject l_GraphicObject in GraphicObjects)
			{
				l_GraphicObject.SyncGraphics(p_Database);
			}
		}

		//
		// Parent Structure
		//

		public void SetParentStructure()
		{
		}

		//
		// Helper Functions
		//
	}

	public class HMIDiagramDictionary : Dictionary<String, HMIDiagram>
	{
	}
}
