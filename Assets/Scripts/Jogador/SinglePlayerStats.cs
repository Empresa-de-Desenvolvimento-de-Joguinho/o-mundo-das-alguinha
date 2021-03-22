using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Jogador
{
    public class SinglePlayerStats : MonoBehaviour
    {
        [SerializeField] private TMP_Text playerPosition;
        [SerializeField] private TMP_Text playersDisplayedName;
        [SerializeField] private Image playersSpriteImage;
        [SerializeField] private Image playerColor;
        [SerializeField] private GameObject display;

        private PlayerMovement player;
        private bool active;

        public void SetPlayer(PlayerMovement player)
        {
            active = true;
            display.SetActive(true);
            this.player = player;
            Character character = player.GetDetails().GetCharacter();
            playerColor.color = character.GetColor();
            playersSpriteImage.sprite = character.GetSprite();
            playersDisplayedName.text = character.GetName();
        }

        private void Update()
        {
            if (active)
            {
                UpdatePlayerPosition();
            }
        }

        private void Awake()
        {
            display.SetActive(false);
            active = false;
        }

        private void UpdatePlayerPosition()
        {
            playerPosition.text = player.ActualCellNumber.ToString();
        }

    }
}