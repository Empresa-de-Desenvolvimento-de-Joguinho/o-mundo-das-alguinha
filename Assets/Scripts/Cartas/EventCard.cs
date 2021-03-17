using Jogador;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Event", order = 2)]
public class EventCard : ScriptableObject
{
	public string description;
	public string actionDescription;
	public int quantityToWalk;
	public int cellNumber;
	public Character[] characters;

	public bool IsEventForCharacter(Character character)
    {
        if (characters == null || characters.Length == 0)
        {
			return false;
		}

		return characters.Any(x => character == x);
	}
}
