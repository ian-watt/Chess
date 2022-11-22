using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Grid<T>
{
    private int2 dims;
    public T[] squares;

    public Grid()
    {
        dims = new int2(8,8);
        squares = new T[64];
    }

    public T Read(int2 value) { return squares[value.y * dims.x + value.x]; }
    public void Write(T square, int2 value) { squares[value.y * dims.x + value.x] = square; }

    public int Width { get { return dims.x; } }
    public int Height {  get { return dims.y; } }
     
}
