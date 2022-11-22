using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class GridManager : MonoBehaviour
{
    public Grid<Square> grid;
    int columns, rows;
    public GameObject squarePrefab;
    private ChessPiece selectedPiece;
    public ChessPiece[] pieces;
    public GameObject[] piecePrefabs;
    private Camera currentCamera;
    public Color whiteColor;
    public Color blackColor;
    private int layerMask = 6;
    private Vector3 currentPosition;
    public Material highlightedMaterial;
    public int turn = 1;
    public TextMeshProUGUI currentTurnText;
    public ChessPiece whiteKing;
    public ChessPiece blackKing;


    private void Start()
    {
        columns = 8;
        turn = 1;
        rows = 8;
        SetupGrid();
        SpawnAllPieces();
        whiteKing = pieces[4];
        blackKing = pieces[20];
        PositionPieces();
        layerMask = 1 << 6;


    }

    private void Update()
    {
        if (turn == 1)
        {
            currentTurnText.text = ("White to move");
        }
        else
        {
            currentTurnText.text = ("Black to move");
        }

        if (turn == -1)
        {
            transform.rotation = Quaternion.AngleAxis(180, Vector3.forward);
            foreach (ChessPiece piece in pieces)
            {
                if (piece != null)
                {
                    piece.gameObject.GetComponent<SpriteRenderer>().flipX = true;
                    piece.gameObject.GetComponent<SpriteRenderer>().flipY = true;
                }

            }
        }
        else
        {
            transform.rotation = Quaternion.AngleAxis(0, Vector3.forward);
            foreach (ChessPiece piece in pieces)
            {
                if (piece != null)
                {
                    piece.gameObject.GetComponent<SpriteRenderer>().flipX = false;
                    piece.gameObject.GetComponent<SpriteRenderer>().flipY = false;
                }
            }
        }

        if (!currentCamera)
        {
            currentCamera = Camera.main;
            return;
        }
        RaycastHit info;
        Ray ray = currentCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out info, 100, layerMask))
        {

            //select a piece
            if (Input.GetMouseButtonDown(0) && selectedPiece != null)
            {
                if (info.transform.gameObject.GetComponent<Square>().gameObject != null)
                {
                    if (selectedPiece.GetLegalMoves(grid).Count > 0)
                    {
                        foreach (Square square in selectedPiece.GetLegalMoves(grid))
                        {
                            if (info.transform.gameObject.GetComponent<Square>().squareID == square.squareID)
                            {
                                selectedPiece.Move(square, grid);
                                DeselectPiece(selectedPiece);
                                turn = -turn;
                            }
                        }
                    }
                    if (selectedPiece != null)
                    {
                        if (info.transform.gameObject.GetComponent<Square>().currentPiece != null && info.transform.gameObject.GetComponent<Square>().currentPiece.teamID == selectedPiece.teamID)
                        {
                            selectedPiece = info.transform.gameObject.GetComponent<Square>().currentPiece;
                            Debug.Log("Selected piece: " + selectedPiece.gameObject.name);
                            DisplayLegalMoves(selectedPiece);
                        }
                    }

                    else
                    {
                        DeselectPiece(selectedPiece);
                    }
                }
            }

            //if no piece selected, select a piece. If an unoccupied tile is selected, do nothing
            if (Input.GetMouseButtonDown(0) && selectedPiece == null)

            {
                if (info.transform.gameObject.GetComponent<Square>().isOccupied && turn == info.transform.gameObject.GetComponent<Square>().currentPiece.teamID)
                {
                    selectedPiece = info.transform.gameObject.GetComponent<Square>().currentPiece;
                    Debug.Log("Selected piece: " + selectedPiece.gameObject.name);
                    DisplayLegalMoves(selectedPiece);
                }
            }
        }
    }


    private void SetupGrid()
    {
        grid = new Grid<Square>();
        for (int i = 0; i < columns; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                SpawnSquare(i, j);
            }
        }
    }
    private void SpawnSquare(int x, int y)
    {

        bool isLightSquare = ((x + y) % 2 != 0);
        GameObject go = Instantiate(squarePrefab);
        Square square = go.GetComponent<Square>();
        grid.Write(square, new int2(x, y));
        square.grid = this;
        go.transform.localPosition = new Vector3(x - 3.5f, y - 3.5f, 0);
        square.position = go.transform.localPosition;
        go.gameObject.transform.parent = transform;
        go.gameObject.name = ("X: " + x + " Y: " + y);
        go.gameObject.layer = 6;
        go.AddComponent<BoxCollider>();
        SpriteRenderer s = go.GetComponent<SpriteRenderer>();

        if (isLightSquare)
        {
            s.color = whiteColor;
        }
        else
        {
            s.color = blackColor;
        }

    }

    [ContextMenu("Spawn Piece Test")]
    private void SpawnAllPieces()
    {
        pieces = new ChessPiece[32];

        //white team
        pieces[0] = SpawnSinglePiece(0, new int2(0, 0), 1);
        pieces[1] = SpawnSinglePiece(1, new int2(1, 0), 1);
        pieces[2] = SpawnSinglePiece(2, new int2(2, 0), 1);
        pieces[3] = SpawnSinglePiece(3, new int2(3, 0), 1);
        pieces[4] = SpawnSinglePiece(4, new int2(4, 0), 1);
        pieces[5] = SpawnSinglePiece(2, new int2(5, 0), 1);
        pieces[6] = SpawnSinglePiece(1, new int2(6, 0), 1);
        pieces[7] = SpawnSinglePiece(0, new int2(7, 0), 1);
        pieces[8] = SpawnSinglePiece(5, new int2(0, 1), 1);
        pieces[9] = SpawnSinglePiece(5, new int2(1, 1), 1);
        pieces[10] = SpawnSinglePiece(5, new int2(2, 1), 1);
        pieces[11] = SpawnSinglePiece(5, new int2(3, 1), 1);
        pieces[12] = SpawnSinglePiece(5, new int2(4, 1), 1);
        pieces[13] = SpawnSinglePiece(5, new int2(5, 1), 1);
        pieces[14] = SpawnSinglePiece(5, new int2(6, 1), 1);
        pieces[15] = SpawnSinglePiece(5, new int2(7, 1), 1);

        //black team
        pieces[16] = SpawnSinglePiece(6, new int2(0, 7), -1);
        pieces[17] = SpawnSinglePiece(7, new int2(1, 7), -1);
        pieces[18] = SpawnSinglePiece(8, new int2(2, 7), -1);
        pieces[19] = SpawnSinglePiece(9, new int2(3, 7), -1);
        pieces[20] = SpawnSinglePiece(10, new int2(4, 7), -1);
        pieces[21] = SpawnSinglePiece(8, new int2(5, 7), -1);
        pieces[22] = SpawnSinglePiece(7, new int2(6, 7), -1);
        pieces[23] = SpawnSinglePiece(6, new int2(7, 7), -1);
        pieces[24] = SpawnSinglePiece(11, new int2(0, 6), -1);
        pieces[25] = SpawnSinglePiece(11, new int2(1, 6), -1);
        pieces[26] = SpawnSinglePiece(11, new int2(2, 6), -1);
        pieces[27] = SpawnSinglePiece(11, new int2(3, 6), -1);
        pieces[28] = SpawnSinglePiece(11, new int2(4, 6), -1);
        pieces[29] = SpawnSinglePiece(11, new int2(5, 6), -1);
        pieces[30] = SpawnSinglePiece(11, new int2(6, 6), -1);
        pieces[31] = SpawnSinglePiece(11, new int2(7, 6), -1);


    }

    private ChessPiece SpawnSinglePiece(int prefab, int2 squareID, int teamID)
    {
        GameObject piece = Instantiate(piecePrefabs[prefab], transform);
        ChessPiece chessPiece = piece.GetComponent<ChessPiece>();
        chessPiece.teamID = teamID;
        chessPiece.squareID = squareID.x + (squareID.y * grid.Width);

        return chessPiece;

    }

    private void PositionPieces()
    {

        foreach (ChessPiece piece in pieces)
        {
            piece.gameObject.transform.localPosition = new Vector3(grid.squares[piece.squareID].position.x, grid.squares[piece.squareID].position.y, -.1f);
            piece.position = piece.gameObject.transform.localPosition;
            grid.squares[piece.squareID].isOccupied = true;
            piece.gameObject.transform.localScale = new Vector3(.8f, .8f, .8f);
            grid.squares[piece.squareID].currentPiece = piece;
            if (piece.teamID == 1)
            {
                piece.myKing = whiteKing;
            }
            else
            {
                piece.myKing = blackKing;
            }

        }
    }

    public int LookupSquareID(GameObject square)
    {
        int x = square.GetComponent<Square>().squareID;
        return x;
    }

    public void DisplayLegalMoves(ChessPiece piece)
    {
        if (this.gameObject.transform.GetComponentInChildren<SphereCollider>() != null)
        {
            foreach (SphereCollider sphereCollider in this.gameObject.transform.GetComponentsInChildren<SphereCollider>())
            {
                Destroy(sphereCollider.gameObject);
            }
        }
        foreach (Square square in piece.GetLegalMoves(grid))
        {
            GameObject go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            go.transform.parent = transform;
            go.transform.localPosition = new Vector3(square.transform.localPosition.x, square.transform.localPosition.y, -.2f);
            go.transform.localScale = new Vector3(.25f, .25f, .25f);
            go.GetComponent<MeshRenderer>().material = highlightedMaterial;

        }
    }

    public void DeselectPiece(ChessPiece piece)
    {
        if (this.gameObject.transform.GetComponentInChildren<SphereCollider>() != null)
        {
            foreach (SphereCollider sphereCollider in this.gameObject.transform.GetComponentsInChildren<SphereCollider>())
            {
                Destroy(sphereCollider.gameObject);
            }

        }
        selectedPiece = null;
        Debug.Log("Deselected the piece");
    }

    public void SelectPiece(ChessPiece piece, RaycastHit info)
    {
        piece = info.transform.gameObject.GetComponent<Square>().currentPiece;
        Debug.Log("Selected piece: " + piece.gameObject.name);
        DisplayLegalMoves(piece);
        selectedPiece = piece;
    }
}

