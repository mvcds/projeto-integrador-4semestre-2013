using System;
using System.Xml.Serialization;
using System.Xml;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PI.Data.XML
{
	public class Quest: XMLBase
	{	
		public Quest()
		{
			path = "Data";
			file = "quests";
		}
		
		#region Overrided Methods			
				
		override public void Insert(object o)
		{	
			throw new NotImplementedException();
		}
		
		override public void Update(object o)
		{
			throw new NotImplementedException();
		}
		
		override public void Delete(object o)
		{
			throw new NotImplementedException();
		}
		
		override public object Select(List<object> o)
		{
			throw new NotImplementedException();
		}
		
        override public List<object> ListAll()
		{	
			List<object> r = new List<object>();
			XmlDocument xml = new XmlDocument();
			uint total = Count();
			
			xml.Load(FullPath());
			for(int i = 0; i < total; i++)
			{	
				XmlNode node = xml.GetElementsByTagName("QUEST")[i];
				
				uint id = uint.Parse(node["ID"].InnerText);
				string name = node["NAME"].InnerText;
				string desc = node["DESCRIPTION"].InnerText;
				int? t = null;
					
				//*Optional XML items
				try
				{
					t = int.Parse(node["TIMER"]["SECONDS"].InnerText);
				}
				catch (Exception e)
				{
				}
				
			
				if (t == null)
				{
					r.Add(new PI.General.Quest(id, name, desc));
				}
				else
				{
					r.Add(new PI.General.Quest(id, name, desc,(int)t));
				}
				//*/
			}
			return r;
				
		}
		
		#endregion
	}
}

