using UnityEngine;
using UnityEngine.UI;

namespace Jogador
{
	public class SingleCharacterSelector : MonoBehaviour
	{
		[SerializeField] private Character[] characters;
		[SerializeField] private Text characterDisplayedName;
		[SerializeField] private Image characterSpriteImage;
		[SerializeField] private GameObject readyText;
		[SerializeField] private GameObject confirmText;
		[SerializeField] private GameObject cancelText;
		[SerializeField] private GameObject addText;
		[SerializeField] private GameObject removeText;
		[SerializeField] private GameObject[] interactionButtons;
		[SerializeField] private GameObject playerSelectionScreen;

		public bool _selected;
		private bool _active;
		private int _currentCharacterIndex;

        public Player GetPlayerCharacter()
		{
			var selectedCharacter = characters[_currentCharacterIndex];
			if (_selected)
			{
				var player = ScriptableObject.CreateInstance<Player>();  
				player.SetCharacter(selectedCharacter);
				return player;
			}

			return null;

		}

		public void NextCharacter()
		{
			if (_currentCharacterIndex + 1 > characters.Length - 1)
			{
				_currentCharacterIndex = 0;
			}
			else
			{
				_currentCharacterIndex++;
			}

			ShowCharacter();
		}

		public void PreviousCharacter()
		{
			if (_currentCharacterIndex - 1 < 0)
			{
				_currentCharacterIndex = characters.Length - 1;
			}
			else
			{
				_currentCharacterIndex--;
			}

			ShowCharacter();
		}

		private void ShowCharacter()
		{
			var currentCharacter = characters[_currentCharacterIndex];
			characterDisplayedName.text = currentCharacter.GetName();
			characterSpriteImage.sprite = currentCharacter.GetSprite();
		}
		
		public void ToggleConfirmation()
		{
			ConfirmSelection(!_selected);
		}

		public void ToggleCharacterSelection()
		{
			_active = !_active;
			playerSelectionScreen.SetActive(_active);
			addText.SetActive(_active);
			removeText.SetActive(!_active);
			ShowCharacter();
		}

		public bool IsSelected()
		{
			return _selected;
		}

		private void ConfirmSelection(bool isSelected)
		{
			_selected = isSelected;
			confirmText.SetActive(!isSelected);
			cancelText.SetActive(isSelected);
			readyText.SetActive(isSelected);

			foreach(var button in interactionButtons)
            {
				button.SetActive(!isSelected);
            }
		}
	}
}