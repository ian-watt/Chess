using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : ChessPiece
{
    public override void Move(Square destination, Grid<Square> grid)
    {
        foreach (Square square in GetLegalMoves(grid))
        {
            if (square.squareID == destination.squareID)
            {
                firstMove = false;
                grid.squares[squareID].isOccupied = false;
                grid.squares[squareID].currentPiece = null;
                gameObject.transform.localPosition = new Vector3(destination.position.x, destination.position.y, -.1f);
                squareID = destination.squareID;
                position = destination.position;
                if (destination.isOccupied == false)
                {
                    destination.isOccupied = true;
                    destination.currentPiece = this;
                }
                else
                {
                    Destroy(destination.currentPiece.gameObject);
                    destination.currentPiece = this;

                }
            }
        }
    }
    public override List<Square> GetLegalMoves(Grid<Square> grid)
    {
        List<Square> list = new List<Square>();
        if(CheckBounds(position, new Vector3(0, 1, 0)))
        {
            if (grid.squares[squareID + up].isOccupied)
            {
                if(grid.squares[squareID + up].currentPiece.teamID != teamID)
                {
                    list.Add(grid.squares[squareID + up]);
                }
            }
            else
            {
                list.Add(grid.squares[squareID + up]);
            }
        }
        if (CheckBounds(position, new Vector3(0, -1, 0)))
        {
            if (grid.squares[squareID + down].isOccupied)
            {
                if (grid.squares[squareID + down].currentPiece.teamID != teamID)
                {
                    list.Add(grid.squares[squareID + down]);
                }
            }
            else
            {
                list.Add(grid.squares[squareID + down]);
            }
        }
        if (CheckBounds(position, new Vector3(1, 1, 0)))
        {
            if (grid.squares[squareID + diagRight].isOccupied)
            {
                if (grid.squares[squareID + diagRight].currentPiece.teamID != teamID)
                {
                    list.Add(grid.squares[squareID + diagRight]);
                }
            }
            else
            {
                list.Add(grid.squares[squareID + diagRight]);
            }
        }
        if (CheckBounds(position, new Vector3(-1, 1, 0)))
        {
            if (grid.squares[squareID + diagLeft].isOccupied)
            {
                if (grid.squares[squareID + diagLeft].currentPiece.teamID != teamID)
                {
                    list.Add(grid.squares[squareID + diagLeft]);
                }
            }
            else
            {
                list.Add(grid.squares[squareID + diagLeft]);
            }
        }
        if (CheckBounds(position, new Vector3(1, 0, 0)))
        {
            if (grid.squares[squareID + left].isOccupied)
            {
                if (grid.squares[squareID + left].currentPiece.teamID != teamID)
                {
                    list.Add(grid.squares[squareID + left]);
                }
            }
            else
            {
                list.Add(grid.squares[squareID + left]);
            }
        }
        if (CheckBounds(position, new Vector3(1, 0, 0)))
        {
            if (grid.squares[squareID + right].isOccupied)
            {
                if (grid.squares[squareID + right].currentPiece.teamID != teamID)
                {
                    list.Add(grid.squares[squareID + right]);
                }
            }
            else
            {
                list.Add(grid.squares[squareID + right]);
            }
        }
        if (CheckBounds(position, new Vector3(-1, -1, 0)))
        {
            if (grid.squares[squareID + -diagRight].isOccupied)
            {
                if (grid.squares[squareID + -diagRight].currentPiece.teamID != teamID)
                {
                    list.Add(grid.squares[squareID + -diagRight]);
                }
            }
            else
            {
                list.Add(grid.squares[squareID + -diagRight]);
            }
        }
        if (CheckBounds(position, new Vector3(1, -1, 0)))
        {
            if (grid.squares[squareID + -diagLeft].isOccupied)
            {
                if (grid.squares[squareID + -diagLeft].currentPiece.teamID != teamID)
                {
                    list.Add(grid.squares[squareID + -diagLeft]);
                }
            }
            else
            {
                list.Add(grid.squares[squareID + -diagLeft]);
            }
        }
        return list;
    }
}
