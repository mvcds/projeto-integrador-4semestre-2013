using UnityEngine;
using UnityEditor;

public class ExampleEditorWindow : EditorWindow {
	
	[MenuItem("Window/Example Editor Window")]
	public static void Init () {
		EditorWindow.GetWindow<ExampleEditorWindow>("Example Editor Window", true);
	}

	void OnGUI () {
		if (GUILayout.Button("Im a button!"))
			Debug.Log("Hello World!");
	}
}
