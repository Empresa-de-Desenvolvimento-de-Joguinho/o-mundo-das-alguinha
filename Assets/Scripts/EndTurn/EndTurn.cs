using System.Collections;
using System.Collections.Generic;
using Turno;
using UnityEngine;

public class EndTurn : TurnComponent
{
    public override void ShowElements()
    {
        FinishComponent();
    }

    protected override void HideComponent()
    {
    }
}
