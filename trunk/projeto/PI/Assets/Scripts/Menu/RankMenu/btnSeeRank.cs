using UnityEngine;
using System.Collections;

public class btnSeeRank : Button {
    
    protected override void Action()
    {
        base.Action();

        _myMenu.SetAble(false);
        Director.Instance.ShowRank();
    }
}
