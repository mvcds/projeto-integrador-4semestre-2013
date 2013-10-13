using UnityEngine;
using System.Collections;

public static class ScreenExtensions
{	
    public static int FixForHundred(this int variable, bool negative = false)
    {
        return (int) FixForHundred((float)variable, negative);
    }

    public static float FixForHundred(this float variable, bool negative = false)
    {
        if (negative && variable < -100)
            variable = -100;
        else if (!negative && variable < 0)
            variable = 0;

        if (variable > 100)
            variable = 100;

        return variable;
    }

	public static int FitOnWidth(this int variable)
	{		
		return (variable * Screen.width) / 100;
	}
	
	public static int FitOnWidth(this float variable)
	{		
		return ((int)variable * Screen.width) / 100;
	}
	
	public static int FitOnHeight(this int variable)
	{		
		return (variable * Screen.height) / 100;
	}
	
	public static int FitOnHeight(this float variable)
	{		
		return ((int)variable * Screen.height) / 100;
	}
}
