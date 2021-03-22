﻿using System.Collections;
using Turno;
using UnityEngine;

public class EndTurn : TurnComponent
{
    public override void ShowElements()
    {
        StartCoroutine(WaitForNextTurn());
    }

    private IEnumerator WaitForNextTurn()
    {
        yield return new WaitForSeconds(1);
        FinishComponent();
    }

    protected override void HideComponent()
    {
    }
}
