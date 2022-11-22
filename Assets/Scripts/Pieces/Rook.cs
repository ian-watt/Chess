using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Rook : ChessPiece
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
        if (teamID == 1)
        {
            for (int i = 1; i < 8; i++)
            {
                if (CheckBounds(position, new Vector3(0, 1 + (i - 1), 0)))
                {
                    if (grid.squares[squareID + (up * i)].isOccupied == false || grid.squares[squareID + (up * i)].currentPiece.teamID != teamID)
                    {
                        list.Add(grid.squares[squareID + (up * i)]);
                    }

                    if (grid.squares[squareID + (up * i)].isOccupied)
                    {
                        break;
                    }
                }
            }
            for (int i = 0; i < 7; i++)
            {
                if (CheckBounds(position, new Vector3(1 + i, 0, 0)))
                {
                    if ((grid.squares[squareID + (right + i)].isOccupied == false || grid.squares[squareID + (right + i)].currentPiece.teamID != teamID))
                    {
                        list.Add(grid.squares[squareID + (right + i)]);
                    }
                    if (grid.squares[squareID + (right + i)].isOccupied)
                    {
                        break;
                    }
                }

            }
            for (int i = 0; i < 7; i++)
            {
                if (CheckBounds(position, new Vector3(-1 - i, 0, 0)))
                {
                    if ((grid.squares[squareID + (left - i)].isOccupied == false || grid.squares[squareID + (left - i)].currentPiece.teamID != teamID))
                    {
                        list.Add(grid.squares[squareID + (left - i)]);
                    }
                    if (grid.squares[squareID + (left - i)].isOccupied)
                    {
                        break;
                    }
                }

            }
            for (int i = 1; i < 8; i++)
            {
                if (CheckBounds(position, new Vector3(0, -1 - (i - 1), 0)))
                {
                    if ((grid.squares[squareID + (down * i)].isOccupied == false || grid.squares[squareID + (down * i)].currentPiece.teamID != teamID))
                    {
                        list.Add(grid.squares[squareID + (down * i)]);
                    }
                    if (grid.squares[squareID + (down * i)].isOccupied)
                    {
                        break;
                    }
                }
            }
            return list;
        }
        else
        {
            for (int i = 1; i < 8; i++)
            {
                if (CheckBounds(position, new Vector3(0, 1 + (i - 1), 0)))
                {
                    if (grid.squares[squareID + (up * i)].isOccupied == false || grid.squares[squareID + (up * i)].currentPiece.teamID != teamID)
                    {
                        list.Add(grid.squares[squareID + (up * i)]);
                    }

                    if (grid.squares[squareID + (up * i)].isOccupied)
                    {
                        break;
                    }
                }
            }
            for (int i = 0; i < 7; i++)
            {
                if (CheckBounds(position, new Vector3(1 + i, 0, 0)))
                {
                    if ((grid.squares[squareID + (right + i)].isOccupied == false || grid.squares[squareID + (right + i)].currentPiece.teamID != teamID))
                    {
                        list.Add(grid.squares[squareID + (right + i)]);
                    }
                    if (grid.squares[squareID + (right + i)].isOccupied)
                    {
                        break;
                    }
                }

            }
            for (int i = 0; i < 7; i++)
            {
                if (CheckBounds(position, new Vector3(-1 - i, 0, 0)))
                {
                    if ((grid.squares[squareID + (left - i)].isOccupied == false || grid.squares[squareID + (left - i)].currentPiece.teamID != teamID))
                    {
                        list.Add(grid.squares[squareID + (left - i)]);
                    }
                    if (grid.squares[squareID + (left - i)].isOccupied)
                    {
                        break;
                    }
                }

            }
            for (int i = 1; i < 8; i++)
            {
                if (CheckBounds(position, new Vector3(0, -1 - (i - 1), 0)))
                {
                    if ((grid.squares[squareID + (down * i)].isOccupied == false || grid.squares[squareID + (down * i)].currentPiece.teamID != teamID))
                    {
                        list.Add(grid.squares[squareID + (down * i)]);
                    }
                    if (grid.squares[squareID + (down * i)].isOccupied)
                    {
                        break;
                    }
                }
            }
            return list;
        }
    }
}
