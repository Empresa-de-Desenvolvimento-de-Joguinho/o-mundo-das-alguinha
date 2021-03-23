using System.Collections.Generic;
using System.Linq;
using Turno;
using UnityEngine;

namespace Jogador
{
	public class CharacterSelector : PlayerSelection
	{
		[SerializeField] private GameObject canvas;
		[SerializeField] private SingleCharacterSelector[] singleCharacterSelector;
		[SerializeField] private GameObject confirmButton;
		private bool canConfirm => singleCharacterSelector.Where(x => x.IsSelected()).Count() >= 2;

		private void Update()
        {
			confirmButton.SetActive(canConfirm);
		}

        public override void ShowElements()
		{
			canvas.SetActive(true);
		}

		protected override void HideComponent()
		{
			canvas.SetActive(false);
		}

		public override IPlayerDetails[] GetPlayers()
		{
			var players = new List<IPlayerDetails>();

			foreach (var characterSelector in singleCharacterSelector)
			{
				if (characterSelector.IsSelected())
				{
					players.Add(characterSelector.GetPlayerCharacter());
				}
			}

			return players.ToArray();
		}
	}


}