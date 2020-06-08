using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PipeDirections{
    DOWN = 1, UP = 2, LEFT = 4, RIGHT = 8, FRONT = 16, BACK = 32
}

public class PipeSystemHandler : MonoBehaviour
{
    public int[,,] pipes;

    void Awake(){
        pipes = new int[Grid.current.gridArray.GetLength(0),Grid.current.gridArray.GetLength(1),Grid.current.gridArray.GetLength(2)];
    }

    public void AddPipe(Vector3 position){
        position =  position / Grid.current.CellSize;
        if (Grid.current.CheckBounds(position + Vector3.down))
        {
        }
    }
}
