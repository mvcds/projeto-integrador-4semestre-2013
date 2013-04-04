using System;

namespace PI
{
	public class FileHandler
	{
		#region Attributes
		
		private string myPath = null,
					   file= null,
					   extension = null;
		
		public string FilePath
		{
			get
			{
				return myPath;
			}
			protected set 
			{
				CheckString(value, myPath);
				myPath = value;
			}
		}
		
		public string FileName
		{
			get
			{
				return file;
			}
			protected set 
			{
				CheckString(value, file);
				file = value;
			}
		}
		
		virtual public string FileExtension
		{
			get
			{
				return extension;
			}
			protected set 
			{
				CheckString(value, extension);
				extension = value;
			}
		}
		
		#endregion
		
		protected FileHandler()
		{
		}
		
		public FileHandler(string p, string f, string x)
		{
			FilePath = p;
			FileName = f;
			FileExtension = x;
		}
		
		public string FullPath()
		{
			if (FilePath == null || FileName == null || FileExtension == null)
				throw new Exception("Valor ainda não declarados");
			return UnityEngine.Application.dataPath + "/" + FilePath + "/" + FileName + "." + FileExtension;
		}
				
		private void CheckString(string s, string my)
		{
			if (s == null)
				throw new Exception("O valor não pode ser nulo");
			if (s == "")
				throw new Exception("O valor não pode ser vazio");	
			if (my != null)
				throw new Exception("Valor já definido");			
		}
		
		public enum Error
		{
			Null,
			Empty,
			AlreadyDefined
		}
		
	}
}

