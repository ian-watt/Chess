using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bishop : ChessPiece
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
        for(int i = 1; i < 8; i++)
        {
            if(CheckBounds(position, new Vector3(1 + (i - 1), 1 + (i - 1), 0)))
            {
                if (grid.squares[squareID + i * diagRight].isOccupied)
                {
                    if (grid.squares[squareID + i * diagRight].currentPiece.teamID != teamID)
                    {
                        list.Add(grid.squares[squareID + i*diagRight]);
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    list.Add(grid.squares[squareID + i * diagRight]);
                }
            }
        }
        for (int i = 1; i < 8; i++)
        {
            if (CheckBounds(position, new Vector3(-1 - (i - 1), 1 + (i - 1), 0)))
            {
                if (grid.squares[squareID + i * diagLeft].isOccupied)
                {
                    if (grid.squares[squareID + i * diagLeft].currentPiece.teamID != teamID)
                    {
                        list.Add(grid.squares[squareID + i * diagLeft]);
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    list.Add(grid.squares[squareID + i * diagLeft]);
                }
            }
        }
        for (int i = 1; i < 8; i++)
        {
            if (CheckBounds(position, new Vector3(1 + (i - 1), -1 - (i - 1), 0)))
            {
                if (grid.squares[squareID + i * -diagLeft].isOccupied)
                {
                    if (grid.squares[squareID + i * -diagLeft].currentPiece.teamID != teamID)
                    {
                        list.Add(grid.squares[squareID + i * -diagLeft]);
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    list.Add(grid.squares[squareID + i * -diagLeft]);
                }
            }
        }
        for (int i = 1; i < 8; i++)
        {
            if (CheckBounds(position, new Vector3(-1 - (i - 1), -1 - (i - 1), 0)))
            {
                if (grid.squares[squareID + i * -diagRight].isOccupied)
                {
                    if (grid.squares[squareID + i * -diagRight].currentPiece.teamID != teamID)
                    {
                        list.Add(grid.squares[squareID + i * -diagRight]);
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    list.Add(grid.squares[squareID + i * -diagRight]);
                }
            }
        }

        return list;

    }
}
