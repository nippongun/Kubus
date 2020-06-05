﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class Grid : MonoBehaviour
{
    [SerializeField]
    private int cellSize;
    [SerializeField]
    private int zSize = 10;
    [SerializeField]
    private int xSize = 10;
    
    private int width;
    private int height;
    

    
    public int Width { get { return width; } }
    public int Height { get { return height; } }
    public int CellSize { get { return cellSize; } }
    public int ZSize { get { return zSize; } }
    public int XSize { get { return xSize; } }
#region constructor 
    int[,] gridArray;
    public Grid(int width, int height, int cellSize){
        this.cellSize = cellSize;
        this.width = width;
        this.height = height;

        gridArray = new int[width, height];

        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < gridArray.GetLength(1); y++)
            {
                
            }
        }
    }
#endregion
    void Start(){
        width = xSize * cellSize;
        height = zSize * cellSize;
        //transform.position = new Vector3(cellSize/2f,0,cellSize/2f);
    }


    public Vector3 GetNearestPointOnGrid(Vector3 position){
        position -= transform.position;
        float xCount = Mathf.Floor(position.x / cellSize)*cellSize;
        float yCount = Mathf.Floor(position.y / cellSize)*cellSize;
        float zCount = Mathf.Floor(position.z / cellSize)*cellSize;

        Vector3 result = new Vector3(xCount,yCount,zCount);
        //result += transform.position;
        return result;
    }


}