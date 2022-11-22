using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Knight : ChessPiece
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
            if (CheckBounds(position, new Vector3(0, 2, 0)))
            {
                if (CheckBounds(position, new Vector3(1, 2, 0)))
                {
                    if (grid.squares[squareID + (2 * up + right)].isOccupied == true)
                    {
                        if (grid.squares[squareID + (2 * up + right)].currentPiece.teamID != teamID)
                        {
                            list.Add(grid.squares[squareID + (2 * up + right)]);
                        }
                    }
                    else
                    {
                        list.Add(grid.squares[squareID + (2 * up + right)]);
                    }

                }
                if (CheckBounds(position, new Vector3(-1, 2, 0)))
                {
                    if (grid.squares[squareID + (2 * up + left)].isOccupied == true)
                    {
                        if (grid.squares[squareID + (2 * up + left)].currentPiece.teamID != teamID)
                        {
                            list.Add(grid.squares[squareID + (2 * up + left)]);
                        }
                    }
                    else
                    {
                        list.Add(grid.squares[squareID + (2 * up + left)]);
                    }

                }
            }
            if (CheckBounds(position, new Vector3(2, 0, 0)))
            {
                if (CheckBounds(position, new Vector3(2, 1, 0)))
                {
                    if (grid.squares[squareID + (2 * right + up)].isOccupied == true)
                    {
                        if (grid.squares[squareID + (2 * right + up)].isOccupied && grid.squares[squareID + (2 * right + up)].currentPiece.teamID != teamID)
                        {
                            list.Add(grid.squares[squareID + (2 * right + up)]);
                        }
                    }
                    else
                    {
                        list.Add(grid.squares[squareID + (2 * right + up)]);
                    }

                }
                if (CheckBounds(position, new Vector3(2, -1, 0)))
                {
                    if (grid.squares[squareID + (2 * right + down)].isOccupied == true)
                    {
                        if (grid.squares[squareID + (2 * right + down)].isOccupied && grid.squares[squareID + (2 * right + down)].currentPiece.teamID != teamID)
                        {
                            list.Add(grid.squares[squareID + (2 * right + down)]);
                        }
                    }
                    else
                    {
                        list.Add(grid.squares[squareID + (2 * right + down)]);

                    }

                }
            }
            if (CheckBounds(position, new Vector3(0, -2, 0)))
            {
                if (CheckBounds(position, new Vector3(1, -2, 0)))
                {
                    if (grid.squares[squareID + (2 * down + right)].isOccupied == true)
                    {
                        if (grid.squares[squareID + (2 * down + right)].isOccupied && grid.squares[squareID + (2 * down + right)].currentPiece.teamID != teamID)
                        {
                            list.Add(grid.squares[squareID + (2 * down + right)]);
                        }
                    }
                    else
                    {
                        list.Add(grid.squares[squareID + (2 * down + right)]);
                    }

                }
                if (CheckBounds(position, new Vector3(-1, -2, 0)))
                {
                    if (grid.squares[squareID + (2 * down + left)].isOccupied == true)
                    {
                        if (grid.squares[squareID + (2 * down + left)].isOccupied && grid.squares[squareID + (2 * down + left)].currentPiece.teamID != teamID)
                        {
                            list.Add(grid.squares[squareID + (2 * down + left)]);
                        }
                    }
                    else
                    {
                        list.Add(grid.squares[squareID + (2 * down + left)]);

                    }

                }
            }
            if (CheckBounds(position, new Vector3(-2, 0, 0)))
            {
                if (CheckBounds(position, new Vector3(-2, 1, 0)))
                {
                    if (grid.squares[squareID + (2 * left + up)].isOccupied == true)
                    {
                        if (grid.squares[squareID + (2 * left + up)].isOccupied && grid.squares[squareID + (2 * left + up)].currentPiece.teamID != teamID)
                        {
                            list.Add(grid.squares[squareID + (2 * left + up)]);
                        }
                    }
                    else
                    {
                        list.Add(grid.squares[squareID + (2 * left + up)]);

                    }

                }
                if (CheckBounds(position, new Vector3(-2, -1, 0)))
                {
                    if (grid.squares[squareID + (2 * left + down)].isOccupied == true)
                    {
                        if (grid.squares[squareID + (2 * left + down)].isOccupied && grid.squares[squareID + (2 * left + down)].currentPiece.teamID != teamID)
                        {
                            list.Add(grid.squares[squareID + (2 * left + down)]);
                        }
                    }
                    else
                    {
                        list.Add(grid.squares[squareID + (2 * left + down)]);

                    }
                }
            }
            return list;
        }
    }
