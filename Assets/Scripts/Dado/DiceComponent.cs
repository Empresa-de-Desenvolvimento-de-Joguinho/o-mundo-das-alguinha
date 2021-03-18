using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

namespace Turno
{
	public class DiceComponent : MoveComponent
	{
		[SerializeField] [Range(1, 6)] private int diceSide;
		private bool canRollDice = true;
		private Animator animator;
		private Random rnd = new Random();

		public override int GetQuantityToMove()
		{
			Start();
			return diceSide;
		}
		public void RollDice()
		{
			if (canRollDice)
			{
				diceSide = rnd.Next();
				showDiceSide(diceSide);
				canRollDice = false;
			}
			throw new System.Exception("It's not possible to roll the dice now.");
		}

		public override void ShowElements()
		{
			throw new System.NotImplementedException();
		}

		protected override void HideComponent()
		{
			throw new System.NotImplementedException();
		}
		void showDiceSide(int diceSide)
		{
			if (diceSide.Equals(1))
				animator.Play("dado_rolando_01");
			if (diceSide.Equals(2))
				animator.Play("dado_rolando_02");
			if (diceSide.Equals(3))
				animator.Play("dado_rolando_03");
			if (diceSide.Equals(4))
				animator.Play("dado_rolando_04");
			if (diceSide.Equals(5))
				animator.Play("dado_rolando_05");
			if (diceSide.Equals(6))
				animator.Play("dado_rolando_06");
		}

		private void Start()
		{
			animator = gameObject.GetComponent<Animator>();
			canRollDice = true;
		}
	}
}