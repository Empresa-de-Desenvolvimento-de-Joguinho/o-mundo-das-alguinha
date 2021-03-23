using System;
using UnityEngine;

namespace Cartas
{	
	[Serializable]
	[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Question", order = 2)]
	public class Question : ScriptableObject
	{
		public string Fact;
		public bool IsTrue;
		//public QuestionZone QuestionZone;
	}

	public enum QuestionZone
	{
		LIMNETIC,
		POLLUTED,
		BENTONIC,
		COAST
	}
}