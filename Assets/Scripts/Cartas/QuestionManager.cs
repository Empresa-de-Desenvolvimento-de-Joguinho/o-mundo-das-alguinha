using System.Collections.Generic;
using System.Linq;
using TMPro;
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

		[SerializeField] public Question[] questions;
		[SerializeField] private TextMeshProUGUI factText;
		[SerializeField] private GameObject canvas;
		[SerializeField] private GameObject deck;
		[SerializeField] private GameObject cardScreen;
		
		[SerializeField]
		private List<Question> _unansweredQuestions;
		private Question _currentQuestion;
		private int _quantityToMove;

		// [SerializeField] private float timeBetweenQuestions = 2f;


		void SetCurrentQuestion()
		{
			int randomQuestionIndex = new Random().NextInt(0, _unansweredQuestions.Count);
			_currentQuestion = _unansweredQuestions[randomQuestionIndex];

			factText.text = _currentQuestion.fact;
		}

		/*
		 * TODO
		 *  Uma alternativa a usar BOOLEAN e criar 2 métodos, seria criar um ENUM(?)
		 */
		/*
		 * TODO - Falta importar métodos a objetos na Unity && 
		 */

		public void ValidateQuestion(bool answer) // true false
		{
			if (_currentQuestion.isTrue == answer)
			{
				Debug.Log(("CERTO"));
				_unansweredQuestions.Remove(_currentQuestion);
				_quantityToMove = 1;
			}
			else
			{
				Debug.Log(("ERRADO"));
				_unansweredQuestions.Remove(_currentQuestion);
				_quantityToMove = -1;
			}
		}

		public void ShowCardScreen()
		{
			deck.SetActive(false);
			cardScreen.SetActive(true);
		}

		public override void ShowElements()
		{
			if (_unansweredQuestions == null || _unansweredQuestions.Count == 0)
			{
				_unansweredQuestions = questions.ToList<Question>();
			}

			SetCurrentQuestion();
			canvas.SetActive(true);
			deck.SetActive(true);
		}

		protected override void HideComponent()
		{
			canvas.SetActive(false);
			cardScreen.SetActive(false);
		}

		public override int GetQuantityToMove()
		{
			return _quantityToMove;
		}
	}
}