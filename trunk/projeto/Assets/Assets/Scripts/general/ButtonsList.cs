using UnityEngine;
using System.Collections;

public class ButtonsList : MonoBehaviour {
	
	public int x, y,
			   width, height;
	public int itens, maxColumns;
	
	void OnGUI(){
		
		int column = 0, row = 0;
				
		for(int i = 0; i < itens; i++){
			
			GUI.Button (new Rect ( (x + width) * column, (y + height) * row, width, height), "Obj" + i);
			
			column++;
			
			if(column == maxColumns){
				column = 0;
				row++;
			}
			
		}		
	}

}
