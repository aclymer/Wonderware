using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Wonderware.Management;
using System.Windows.Media;
using System.Diagnostics;
using Wonderware.HelperClasses;

namespace Wonderware.Data
{
	public delegate void ClickedEventHandler(GraphicObject p_IlvObject, String p_sEventID);

	public class GraphicObject : XMLPersistedObject
	{
		public event ClickedEventHandler ClickedEvent;

		public GraphicObject()
		{
			ID = String.Empty;
			TITLE = String.Empty;
			BGCOLOR = String.Empty;
		}

		~GraphicObject()
		{
			if (ClickedEvent != null)
			{
				ClickedEvent = null;
			}
		}

		public void FireClickEvent(String p_sEventID)
		{
			if (ClickedEvent != null)
			{
				ClickedEvent(this, p_sEventID);
			}
			if (Parent != null)
			{
				(Parent as GraphicObject).FireClickEvent(p_sEventID);
			}
		}

		//
		// XML Persisted Properties
		//

		// Attributes
		[AttributeIsXMLAttribute()]
		public String ID;
		[AttributeIsXMLAttribute()]
		public String TITLE;
		[AttributeIsXMLAttribute()]
		public String BGCOLOR;
		[AttributeIsXMLAttribute()]
		public String FILLCOLOR;
		[AttributeIsXMLAttribute()]
		public String COLORREF;
		[AttributeIsXMLAttribute()]
		public String FILLSTYLE;
		[AttributeIsXMLAttribute()]
		public String PENSTYLE;
		[AttributeIsXMLAttribute()]
		public String PENCOLOR;
		[AttributeIsXMLAttribute()]
		public float PENWIDTH;
		[AttributeIsXMLAttribute()]
		public String BEHAVIORLIST;
		[AttributeIsXMLAttribute()]
		public int ROTATION;

		// Properties

		// Sub Elements
		public wwDimension DIMENSION;

		public override bool IsSubElement(String p_sName)
		{
			switch (p_sName)
			{
				case "DIMENSION":
				case "POINT":
				case "FROMPOINT":
				case "TOPOINT":
					return true;
				default:
					return base.IsSubElement(p_sName);
			}
		}

		public override XMLPersistedObject GetSubElementObject(String p_sName)
		{
			switch (p_sName)
			{
				case "DIMENSION":
					return new wwDimension();
				case "POINT":
				case "FROMPOINT":
				case "TOPOINT":
					return new wwPoint();
				default:
					return null;
			}
		}

		public override void AddSubElementObject(XMLPersistedObject p_SubElementObject)
		{
			wwDimension l_Dimension = p_SubElementObject as wwDimension;

			if (l_Dimension != null)
			{
				DIMENSION = l_Dimension;
			}
		}

		//
		// Syncing
		//

		public virtual void SyncData(Database p_Database)
		{
		}

		public virtual void SyncGraphics(Database p_Database)
		{
		}
	}

	public class GraphicObjectDictionary : Dictionary<String, GraphicObject>
	{
	}

	public class GraphicObjectList : List<GraphicObject>
	{
	}

	
}
