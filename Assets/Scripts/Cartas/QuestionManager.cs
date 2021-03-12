using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Security.Cryptography;
using Turno;
using UnityEngine;
using UnityEngine.UI;
using Random = Unity.Mathematics.Random;

namespace Cartas
{
	public class QuestionManager : MoveComponent
	{
		/*
		 * ZONA LIMNÉTICA	-> LIMNETIC 
		 * ZONA POLUÍDA		-> POLLUTED 
		 * ZONA BENTÔNICA	-> BENTONIC
		 * ZONA LITORÂNEA	-> COAST
		*/
		// public Question[] LimneticQuestions;
		// public Question[] PollutedQuestions;
		// public Question[] BentonicQuestions;
		// public Question[] CoastQuestions;
		public Question[] questions;
		private static List<Question> unansweredQuestions;
		private Question currentQuestion;

		[SerializeField] private Text factText;
		// void Start()
		// {
		// 	if (unansweredQuestions == null || unansweredQuestions.Count == 0)
		// 	{
		// 		unansweredQuestions = questions.ToList<Question>();
		// 	}
		// 	GetRandomQuestion();
		// }

		void SetCurrentQuestion()
		{
			int randomQuestionIndex = new Random().NextInt(0, unansweredQuestions.Count);
			currentQuestion = unansweredQuestions[randomQuestionIndex];

			factText.text = currentQuestion.fact;
			unansweredQuestions.RemoveAt(randomQuestionIndex);
		}

		/*
		 * TODO
		 *  Uma alternativa a usar BOOLEAN e criar 2 métodos, seria criar um ENUM(?)
		 */
		/*
		 * TODO - Falta importar métodos a objetos na Unity && 
		 */
		public void UserSelectTrue()
		{
			if (currentQuestion.isTrue)
			{
				Debug.Log(("CERTO"));
			}
			else
			{
				Debug.Log(("ERRADO"));
			}
		}
		
		public void UserSelectFalse()
		{
			if (!currentQuestion.isTrue)
			{
				Debug.Log(("CERTO"));
			}
			else
			{
				Debug.Log(("ERRADO"));
			}
		}

		public override void ShowElements()
		{
			if (unansweredQuestions == null || unansweredQuestions.Count == 0)
			{
				unansweredQuestions = questions.ToList<Question>();
			}

			SetCurrentQuestion();
			throw new System.NotImplementedException();
		}

		protected override void HideComponent()
		{
			throw new System.NotImplementedException();
		}

		public override int GetQuantityToMove()
		{
			/*TODO
			 * A função GetQuantityToMove deverá retornar +1 ou -1 dependendo se o jogador acertou ou errou a pergunta
			 */
			throw new System.NotImplementedException();
		}
	}
}