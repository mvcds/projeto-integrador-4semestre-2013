using UnityEngine;
using System.Collections;

public static class ScreenUtil
{	
	public static int FixForHundred(int variable, bool negative = false)
	{
		return (int) FixForHundred((float)variable, negative);
	}
	
	public static float FixForHundred(float variable, bool negative = false)
	{		
		if (negative && variable < -100)
			variable = -100;
		else if (!negative && variable < 0)
			variable = 0;
		
		if (variable > 100)
			variable = 100;
		
		return variable;
	}
	
	public static int FitOnWidth(int variable)
	{		
		return (variable * Screen.width) / 100;
	}
	
	public static int FitOnWidth(float variable)
	{		
		return ((int)variable * Screen.width) / 100;
	}
	
	public static int FitOnHeight(int variable)
	{		
		return (variable * Screen.height) / 100;
	}
	
	public static int FitOnHeight(float variable)
	{		
		return ((int)variable * Screen.height) / 100;
	}
}
