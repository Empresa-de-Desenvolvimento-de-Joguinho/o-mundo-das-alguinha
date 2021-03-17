using System;
using UnityEngine;

namespace Cartas
{	
	[Serializable]
	[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Question", order = 2)]
	public class Question : ScriptableObject
	{
		public string fact;
		public bool isTrue;
	}
}