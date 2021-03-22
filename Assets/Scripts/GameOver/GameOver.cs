using Turno;
using UnityEngine;

public class GameOver : TurnComponent
{
    [SerializeField] PlayerEndGameInfo[] _playerEndGameInfos;
    [SerializeField] private GameObject canvas;
    public void SetPlayerData(PlayerMovement[] playerMovements)
    {
        for(int x=0; x< playerMovements.Length; x++)
        {
            _playerEndGameInfos[x].SetPlayerData(playerMovements[x]);
        }
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
