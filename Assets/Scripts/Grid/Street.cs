using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StreetDirections{
    REGULAR = 1, NORTH = 2, EAST = 4, SOUTH = 8, WEST = 16
}

public class Street : MonoBehaviour
{
    public int bitmap;

    void Start(){
        AddStreet(transform.position);
    }
    public void AddStreet(Vector3 position){
        position = position / Grid.current.CellSize;
        

        if((int)position.x == 0){
            bitmap |= (int)StreetDirections.WEST;
        }
        if((int)position.x == Grid.current.XSize - 1){
            bitmap |= (int)StreetDirections.EAST;
        }
        if((int)position.z == 0){
            bitmap |= (int)StreetDirections.SOUTH;
        }
        if((int)position.z == Mathf.RoundToInt(Grid.current.ZSize) -1){
            bitmap |= (int)StreetDirections.NORTH;
        }
       

        Vector2Int p = new Vector2Int((int)position.x,(int)position.z);
        
        

        Debug.Log("Print return value of StreetmManager:"+StreetManager.current[(int)p.x,(int)p.y]);

        // Above
        bool alone = true;
        if (StreetManager.current[p.x,p.y+1] != 0)
        {
            bitmap |= (int)StreetDirections.NORTH;
            alone = false; 
        }if(StreetManager.current[p.x+1,p.y] != 0){
            bitmap |= (int)StreetDirections.EAST;
            alone = false;
        }if(StreetManager.current[p.x,p.y-1] != 0){
            bitmap |= (int)StreetDirections.SOUTH;
            alone = false;
        }if(StreetManager.current[p.x-1,p.y] != 0){
            bitmap |= (int)StreetDirections.WEST;
            alone = false;
        }
        if(alone){
            bitmap = (int)StreetDirections.REGULAR;
        }

        StreetManager.current.AddStreetToArray(p,bitmap);
        Debug.Log(p);
        Debug.Log("Type: Street - Position:" + position + " - bitmap " + bitmap);
    }
}
