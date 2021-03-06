﻿using Turno;

public abstract class IPlayerBoardMovement: TurnComponent
{
    public abstract void SetInnitialPosition(PlayerMovement[] players);
    public abstract void SetPlayerMovement(PlayerMovement player, int quantityToWalk);
    public abstract CellType GetLandedCell();
    public abstract bool IsWinner(PlayerMovement player);
}