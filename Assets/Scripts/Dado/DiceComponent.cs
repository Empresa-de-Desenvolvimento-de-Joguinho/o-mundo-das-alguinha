using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

namespace Turno
{
	public abstract class DiceComponent : TurnComponent
	{
		[SerializeField] private GameObject _dado;
		[SerializeField] [Range(1, 6)] private int diceSide;
		private bool canRollDice = true;
		private Animator animator;
		private Random rnd = new Random();

		public int GetQuantityToMove()
		{
			Start();
			RollDice();
			return diceSide;
		}
		public virtual void RollDice()
		{
			if (!canRollDice)
			{
				throw new System.Exception("It's not possible to roll the dice now.");
			}
			diceSide = rnd.Next();
			showDiceSide(diceSide);
			canRollDice = false;
		}

		public override void ShowElements()
		{
			_dado.SetActive(true);
		}

		protected override void HideComponent()
		{
			_dado.SetActive(false);
		}
		void showDiceSide(int diceSide)
		{
			animator.Play($"dado_rolando_0{diceSide}");
		}

		private void Start()
		{
			ShowElements();
			animator = gameObject.GetComponent<Animator>();
			canRollDice = true;
		}
	}
}