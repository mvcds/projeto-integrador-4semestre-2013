using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System;

namespace PI.Backend
{
	abstract public class XMLHandler {
	
		#region Proprieties		
		private string _name = null;
		
		public string Name
		{
			get
			{
				if (_name == null)
					throw new Exception("This file name hasn't been declared.");
				return _name;
			}
			protected set
			{
				if (_name != null)
					throw new Exception("This file has already been named.");
				_name = value;
			}
		}
		
		public string FullPath
		{
			get
			{
				return UnityEngine.Application.dataPath + "/Plugin/" + Name + ".xml";
			}
		}
		
		#pragma warning disable 219
		public int Nodes
		{
			get
			{
				XmlDocument xml = new XmlDocument();
				int i = 0;	
				
				xml.Load(FullPath);
				foreach(XmlElement e in xml.DocumentElement)
					i++;					
				return i;
			}
		}		
		#pragma warning restore 219		
		#endregion
		
		#region Methods
		protected XMLHandler()
		{
		}
		
		static void Error(string msg)
		{
			if (msg == null || msg == "")
				return;
			
			StreamWriter writter;
			FileInfo f = new FileInfo(Application.dataPath + "/ErrorLog.txt");
			if (f.Exists)
				f.Delete();
			writter = f.CreateText();
			writter.Write(msg);			
			writter.Close();
			
			Debug.Log("###The game has generated an Error Log doccument, please check it at Assets folder###");
			Application.Quit();
		}
		#endregion
	}	
}
