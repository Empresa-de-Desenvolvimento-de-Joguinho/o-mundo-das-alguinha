using System.Collections.Generic;
using TMPro;
using Turno;
using UnityEngine;
using Random = System.Random;

namespace Cartas
{
	public class QuestionManager : MoveComponent
	{
		[SerializeField] public Question[] questions;
		[SerializeField] private TextMeshProUGUI factText;
		[SerializeField] private GameObject canvas;
		[SerializeField] private GameObject deck;
		[SerializeField] private GameObject cardScreen;
		
		private List<Question> _unansweredQuestions;
		private Question _currentQuestion;
		private int _quantityToMove;
		private Random rnd = new Random();


		private void Start()
		{
			_unansweredQuestions = new List<Question>(questions);
		}

		void SetCurrentQuestion()
		{
			int randomQuestionIndex = rnd.Next(_unansweredQuestions.Count - 1);
			_currentQuestion = _unansweredQuestions[randomQuestionIndex];

			factText.text = _currentQuestion.Fact;
		}

		public void ValidateQuestion(bool answer)
		{
			if (_currentQuestion.IsTrue == answer)
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
				_unansweredQuestions = new List<Question>(questions);
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