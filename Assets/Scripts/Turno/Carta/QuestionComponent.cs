using System.Collections;
using System.Collections.Generic;
using Turno;
using UnityEngine;

public class QuestionComponent : MoveComponent
{
	[SerializeField] private List<Question> questions;
	[SerializeField] private Question activeQuestion;
	[SerializeField] private bool wasAnsweredRight;

	public void GetQuestion()
    {

    }

	public void ShowQuestion()
    {

    }
	public override int GetQuantityToMove()
	{

		return 1;
	}

	public override void ShowElements()
	{
		throw new System.NotImplementedException();
	}

	protected override void HideComponent()
	{
		throw new System.NotImplementedException();
	}

	private class Question
	{

	}
}
