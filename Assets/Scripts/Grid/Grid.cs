using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public static Grid current;

    [SerializeField]
    private int cellSize = 100;
    [SerializeField]
    private int zSize = 10;
    [SerializeField]
    private int ySize = 10;
    [SerializeField]
    private int xSize = 10;
    
    public int[,,] gridArray;

    private int width;
    private int height;
    
    private Vector3 gridOffset;

    public int Width { get { return width; } }
    public int Height { get { return height; } }
    public int CellSize { get { return cellSize; } }
    public int ZSize { get { return zSize; } }
    public int XSize { get { return xSize; } }
    public int YSize { get { return ySize; } }
    void Awake(){
        current = this;
        gridArray = new int[xSize,ySize,zSize];
    }

    void Start(){
        width = xSize * cellSize;
        height = zSize * cellSize;
        gridOffset = new Vector3(cellSize/2f,0,cellSize/2f);
        DrawGridLines();
    }

    public Vector3 GetNearestPointOnGrid(Vector3 position){
        position -= transform.position;
        float xCount = Mathf.Floor(position.x / cellSize)*cellSize;
        float yCount = Mathf.Floor(position.y / cellSize)*cellSize;
        float zCount = Mathf.Floor(position.z / cellSize)*cellSize;

        Vector3 result = new Vector3(xCount,yCount,zCount);

        return result;
    }

    private void OnDrawGizmos(){
        if(Time.timeScale > 0){
            Gizmos.color = Color.red;

            for (int x = 0; x < (xSize)*(zSize); x++)
            {
                Gizmos.DrawSphere(new Vector3((x%xSize)*cellSize,0f,Mathf.Floor(x/xSize)*cellSize) + gridOffset,10f);
            }
        }
    }

    private void DrawGridLines(){
        LineRenderer line = gameObject.AddComponent<LineRenderer>();
        line.sortingLayerName = "OnTop";
        line.sortingOrder = 5;

        line.positionCount = 6*xSize;

        line.SetPosition(0, new Vector3(0f,0f,0f));
        line.SetPosition(1, new Vector3(cellSize*xSize,0f,0f));
        line.SetPosition(2, new Vector3(cellSize*xSize,0f,cellSize*zSize));
        line.SetPosition(3, new Vector3(0f,0f,cellSize*zSize));
    }

    public void InsertBlock(Vector3 position, int id){
        position = position / cellSize;
        gridArray[(int)position.x,(int)position.y,(int)position.z] = id;
    }

    public bool CheckBounds(Vector3 position){

        if((position.x > 0 && position.x <= xSize) && (position.y >= 0 && position.y < ySize) && (position.z >= 0 && position.z <= zSize)){
            return true;
        } else { 
            return false;
        }
    }
}
