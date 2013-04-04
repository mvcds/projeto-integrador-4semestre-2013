using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.IO;
using System;

namespace PI.Data.XML
{
	public class XMLBase : PI.FileHandler
	{		
		#region SQL-like operations
		
		//abstract public void Create();
		virtual public void Insert(object o)
		{	
			throw new NotImplementedException();
		}
		
		virtual public void Update(object o)
		{
			throw new NotImplementedException();
		}
		
		virtual public void Delete(object o)
		{
			throw new NotImplementedException();
		}
		
		virtual public object Select(List<object> o)
		{
			throw new NotImplementedException();
		}
		
        virtual public List<object> ListAll()
		{	
			throw new NotImplementedException();
		}
		
		#endregion
		
		#region XML Commom	
				
		protected XMLBase()
		{
			FileExtension = "xml";
		}
				
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
				
		public uint Count()
		{
			XmlDocument xml = new XmlDocument();			
			uint i = 0;	
			
			xml.Load(FullPath());
			foreach(XmlElement e in xml.DocumentElement)
				i++;
			return i;
		}
		
		static public void WriteErrorLog(string s)
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

