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
	public class Quest: I_Commands
	{		
		#region Proprietirs
		
		private string path = "Data";
		private string file = "Teste.txt";
		
		#endregion
		
		#region Operations
			
		public void Create()
		{
			StreamWriter writter;
			FileInfo f = new FileInfo(Application.dataPath + "/" + path + "/" + file);
			if (f.Exists)
				f.Delete();
			writter = f.CreateText();
			writter.Write("#test");
			writter.Close();
		}
		
		public void Insert(object o)
		{	
			throw new NotImplementedException();
		}
		
		public void Update(object o)
		{
			throw new NotImplementedException();
		}
		
		public void Delete(object o)
		{
			throw new NotImplementedException();
		}
		
		public object Select(List<object> o)
		{
			throw new NotImplementedException();
		}
		
        public List<object> ListAll()
		{
			throw new NotImplementedException();
		}
		
		#endregion
	}
}

