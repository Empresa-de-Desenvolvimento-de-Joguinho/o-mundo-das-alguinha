using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerEndGameInfo : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerName;
    [SerializeField] private TextMeshProUGUI congratsText;
    [SerializeField] private TextMeshProUGUI house;
    [SerializeField] private Image image;
    [SerializeField] private GameObject playerInfo;

    public void SetPlayerData(PlayerMovement playerMovement)
    {
        playerInfo.SetActive(true);

        var cellNumber = playerMovement.ActualCell.CellNumber;

        if (cellNumber == 40)
        {
            congratsText.text = $"você chegou até o final!";
        }
        else
        {
            congratsText.text = $"você chegou até a casa {cellNumber}!";
        }

        var character = playerMovement.GetDetails().GetCharacter();

        image.sprite = character.GetSprite();
        playerName.text = character.GetName();
        house.text = $"{cellNumber}/40";
    }
}
