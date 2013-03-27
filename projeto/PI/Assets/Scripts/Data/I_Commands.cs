using System;
//using System.Xml.Linq;
using System.Collections;
using System.Collections.Generic;

namespace PI.Data
{
	public interface I_Commands
	{
		void Create();
		void Insert(object o);
		void Update(object o);
		void Delete(object o);
		object Select(List<object> o);
        List<object> ListAll();
	}
}

