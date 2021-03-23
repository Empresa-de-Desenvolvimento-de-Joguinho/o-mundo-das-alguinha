using Jogador;
using TMPro;
using Turno;
using UnityEngine;

public class StartComponent: TurnComponent
{

    [SerializeField] private GameObject canvas;
    [SerializeField] private TextMeshProUGUI titleText;

    private IPlayerDetails currentPlayer;

    public void SetPlayer(IPlayerDetails player)
    {
        currentPlayer = player;
        var playeyName = currentPlayer.GetCharacter().GetName();

        titleText.text = $"{playeyName}, é o seu turno!!";
    }

    public override void ShowElements()
    {
        canvas.SetActive(true);
    }

    protected override void HideComponent()
    {
        canvas.SetActive(false);
    }
}