using TMPro;
using UnityEngine;
using System.Linq;
using Turno;
using Jogador;

public class EventManager : MoveComponent
{
	[SerializeField] public EventCard[] _events;
	[SerializeField] private TextMeshProUGUI _eventDescription;
	[SerializeField] private TextMeshProUGUI _eventAction;
	[SerializeField] private GameObject _canvas;
	[SerializeField] private GameObject _deck;
	[SerializeField] private GameObject _cardScreen;

	private int quantityToMove;
	private int actualCellNumber;
	private Character currentCharacter;

	private EventCard currentEvent => _events.FirstOrDefault(x => x.cellNumber == actualCellNumber);

	public void SetPlayer(PlayerMovement player)
    {
		actualCellNumber = player.ActualCellNumber;
		currentCharacter = player.GetDetails().GetCharacter();
	}

	public void ShowCardScreen()
	{
		_eventDescription.text = currentEvent?.description;
		_eventAction.text = currentEvent?.actionDescription;

		if (currentEvent && currentEvent.IsEventForCharacter(currentCharacter))
		{
			quantityToMove = currentEvent.quantityToWalk;
        }
        else
        {
			quantityToMove = 0;
        }

		_deck.SetActive(false);
		_cardScreen.SetActive(true);
	}

    public override void ShowElements()
	{
		_canvas.SetActive(true);
		_deck.SetActive(true);
	}

	protected override void HideComponent()
	{
		_canvas.SetActive(false);
		_cardScreen.SetActive(false);
	}

	public override int GetQuantityToMove()
	{
		return quantityToMove;
	}
}
