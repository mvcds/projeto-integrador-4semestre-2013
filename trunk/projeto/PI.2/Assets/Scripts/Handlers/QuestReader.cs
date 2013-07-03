using System;
using System.Xml.Serialization;
using System.Xml;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PI.Backend
{
	public class QuestReader : XMLReader {
	
		#region Methods
		public QuestReader()
		{
			Name = "quests";
		}
		
		override public List<GameComponent> ListAll()
		{			
			List<GameComponent> r = new List<GameComponent>();
			XmlDocument xml = new XmlDocument();
			
			xml.Load(FullPath);
			for(int i = 0; i < Nodes; i++)
			{	
				XmlNode node = xml.GetElementsByTagName("QUEST")[i];
				
				uint id = uint.Parse(node["ID"].InnerText);
				string name = node["NAME"].InnerText;
				string desc = node["DESCRIPTION"].InnerText;
				//TODO: int? t = null;
					
				//*Optional XML items
				try
				{
					//t = int.Parse(node["TIMER"]["SECONDS"].InnerText);
				}
				
				catch
				{
				}	
				
				Quest quest;
				quest = new Quest(id, name, desc, false);//TODO: change				
				/*TODO
				if (t == null)
				{
					//r.Add(new Quest(id, name, desc));
				}
				else
				{
					//r.Add(new Quest(id, name, desc,(int)t));
				}*/
				r.Add(quest);
				//*/
			}
			return r;
		}
		#endregion
	}	
}
