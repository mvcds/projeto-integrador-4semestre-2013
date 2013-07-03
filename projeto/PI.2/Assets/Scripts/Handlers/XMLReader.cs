using UnityEngine;
using System.Collections.Generic;
using System;

namespace PI.Backend
{
	abstract public class XMLReader : XMLHandler {
	
		#region Methods
		protected XMLReader()
		{
		}
		
		abstract public List<GameComponent> ListAll();
		#endregion
	}	
}
