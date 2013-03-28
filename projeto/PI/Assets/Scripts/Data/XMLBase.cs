using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.IO;

namespace PI.Data.XML
{
	abstract public class XMLBase
	{
		protected string path, file;
						
		//abstract public void Create();
		abstract public void Insert(object o);//TODO: probably won't be used for all classes
		abstract public void Update(object o);//TODO: probably won't be used for all classes
		abstract public void Delete(object o);//TODO: probably won't be used for all classes
		abstract public object Select(List<object> o);//TODO: probably won't be used for all classes
        abstract public List<object> ListAll();
		
		#region Common		
		
		public void Write(bool deleteExistence, string s)
		{
			/*TODO: probably won't be used for all classes
			StreamWriter writter;
			FileInfo f = new FileInfo(Application.dataPath + "/" + path + "/" + file + ".xml");
			if (f.Exists && deleteExistence)
				f.Delete();
			writter = f.CreateText();
			writter.Write(s);
			writter.Close();
			*/
		}
		
		protected string FullPath()
		{
			return Application.dataPath + "/" + path + "/" + file + ".xml";
		}
		
		public uint Count()
		{
			XmlDocument xml = new XmlDocument();			
			uint i = 0;	
			
			xml.Load(FullPath());
			foreach(XmlElement e in xml.DocumentElement)
				i++;
			return i;
		}
		
		static public void WriteLog(string s)
		{
			if (s == null || s == "")
				return;
			
			StreamWriter writter;
			FileInfo f = new FileInfo(Application.dataPath + "/ErrorLog.txt");
			if (f.Exists)
				f.Delete();
			writter = f.CreateText();
			writter.Write(s);			
			writter.Close();
			
			Debug.Log("###The game has generated an Error Log doccument, please check it at Assets folder###");
			Application.Quit();
		}
		
		#endregion
	}
}

