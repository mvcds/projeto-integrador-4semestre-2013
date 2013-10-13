using UnityEngine;
using System.Collections;
using System;

public class btnIniciar : Button {
	protected override void Action(){
        //TODO: select level
        Director.Instance.RunLevel(Director.DEFAULT_LEVEL_NAME);
	}
}
