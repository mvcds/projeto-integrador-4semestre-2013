using System.Collections;
using System;

namespace PI.Backend
{
	public class GameComponent {	
		#region Proprieties
		public uint ID
		{
			get;
			protected set;
		}
		
		public string Name
		{
			get;
			protected set;
		}
		#endregion
		
		#region Methods		
		protected GameComponent()
		{
		}
		#endregion
	}
}	
