using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;
using UnityEngine.Scripting.APIUpdating;
using Unity.VisualScripting;

public abstract class ChessPiece : MonoBehaviour
{
    public const int up = 8;
    public const int diagLeft = 7;
    public const int diagRight = 9;
    public const int right = 1;
    public const int left = -1;
    public const int down = -8;
    public const int bounds = 64;

    public int squareID;
    public bool firstMove = true;
    public Vector3 position;

    public ChessPiece myKing;
    public GridManager gridManager;



    //white = 1 black = -1
    public int teamID;

    private void Start()
    {
        gridManager = FindObjectOfType<GridManager>();
    }

    public abstract void Move(Square destination, Grid<Square> grid);
    public abstract List<Square> GetLegalMoves(Grid<Square> grid);

    protected bool CheckBounds(Vector3 initialPos, Vector3 checkPos)
    {
        if ((initialPos.x + checkPos.x) > -4 && (initialPos.x + checkPos.x) < 4 && (initialPos.y + checkPos.y) > -4 && (initialPos.y + checkPos.y) < 4)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public List<Square> MoveWithCheckPrevention(ChessPiece originalPiece, List<Square> originalList, Grid<Square> grid, ChessPiece king)
    {
        List<Square> otherTeamList = new List<Square>();
        List<ChessPiece> oppositePieces = new List<ChessPiece>();
        Square originalSquare = grid.squares[originalPiece.squareID];
        int originalSquareID = originalPiece.squareID;
        for (int i = 0; i < gridManager.pieces.Length; i++)
        {
            if (gridManager.pieces[i].teamID != originalPiece.teamID)
            {
                oppositePieces.Add(gridManager.pieces[i]);
            }
        }

        return originalList;
    }
}
//for each move in the original list of moves, iterate through each enemy team piece and set the originalpiece to that move's square. Then iterate through each enemy pieces
//new legal moves in the new position, and if that position has a legal move from the enemy team which could capture the king, remove that move from the original list, and set the
// board position back to the original state.