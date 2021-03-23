using Jogador;
using UnityEngine;

public class PlayersDisplayer : MonoBehaviour
{
    [SerializeField] private SinglePlayerStats[] singlePlayerStats;

    public void SetPlayerStats(PlayerMovement[] playerMovement)
    {
        for (int x = 0; x < playerMovement.Length; x++)
        {
            singlePlayerStats[x].SetPlayer(playerMovement[x]);
        }
    }
}
