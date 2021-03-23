using Turno;
using UnityEngine;
using System.Linq;

public class GameOver : TurnComponent
{
    [SerializeField] PlayerEndGameInfo[] _playerEndGameInfos;
    [SerializeField] private GameObject canvas;
    
    public void SetPlayerData(PlayerMovement[] playerMovements)
    {
        var orderedPlayers = playerMovements.OrderByDescending(x => x.ActualCellNumber).ToArray();
        for(int x=0; x< playerMovements.Length; x++)
        {
            _playerEndGameInfos[x].SetPlayerData(orderedPlayers[x]);
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
