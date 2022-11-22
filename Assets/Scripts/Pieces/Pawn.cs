using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : ChessPiece
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
            if (CheckBounds(position, new Vector3(0, 1, 0)))
            {
                if (grid.squares[squareID + up].isOccupied == false)
                {
                    list.Add(grid.squares[squareID + up]);
                }

                if (grid.squares[squareID + diagLeft].isOccupied && CheckBounds(position, new Vector3(-1, 1, 0)) && grid.squares[squareID + diagLeft].currentPiece.teamID != teamID)
                {
                    list.Add(grid.squares[squareID + diagLeft]);
                }

                if (grid.squares[squareID + diagRight].isOccupied && CheckBounds(position, new Vector3(1, 1, 0)) && grid.squares[squareID + diagRight].currentPiece.teamID != teamID)
                {
                    list.Add(grid.squares[squareID + diagRight]);


                }

                if (firstMove && grid.squares[squareID + (2 * up)].isOccupied == false)
                {

                    list.Add(grid.squares[squareID + (2 * up)]);


                }
            }

        }
        else
        {
            if (CheckBounds(position, new Vector3(0, -1, 0)))
            {
                if (grid.squares[squareID + -up].isOccupied == false)
                {

                    list.Add(grid.squares[squareID + -up]);


                }

                if (grid.squares[squareID + -diagLeft].isOccupied && CheckBounds(position, new Vector3(1, -1, 0)) && grid.squares[squareID + -diagLeft].currentPiece.teamID != teamID)
                {

                    list.Add(grid.squares[squareID + -diagLeft]);


                }

                if (grid.squares[squareID + -diagRight].isOccupied && CheckBounds(position, new Vector3(-1, -1, 0)) && grid.squares[squareID + -diagRight].currentPiece.teamID != teamID)
                {

                    list.Add(grid.squares[squareID + -diagRight]);

                }

                if (firstMove && grid.squares[squareID + (2 * -up)].isOccupied == false)
                {


                    list.Add(grid.squares[squareID + (2 * -up)]);


                }
            }

        }
        return list;
    }
}

