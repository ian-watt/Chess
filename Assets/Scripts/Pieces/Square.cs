using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;

public class Square : MonoBehaviour
{
    public Vector3 position;
    public GridManager grid;
    public bool isOccupied;
    public ChessPiece currentPiece;

    [ContextMenu("Get squareID")]
    public int GetSquareID()
    {
        Debug.Log(squareID);
        return squareID;
        
    }
    public int squareID
    {
        get
        {
            return (int)(position.x + 3.5f) + (int)((position.y +3.5f) * 8 );
        }
        set { squareID = value; }
    }
}
