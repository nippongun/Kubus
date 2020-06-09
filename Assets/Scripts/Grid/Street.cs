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

        Vector2Int p = new Vector2Int((int)position.x,(int)position.z);
        
        Debug.Log("Print return value of StreetmManager:"+StreetManager.current[(int)p.x,(int)p.y]);

        // Above
        if(UpdateBitmap(position)){
            bitmap = (int)StreetDirections.REGULAR;
        }

        StreetManager.current.AddStreetToArray(p,bitmap,this);
        Debug.Log(p);
        Debug.Log("Type: Street - Position:" + position + " - bitmap " + bitmap);
    }

    bool UpdateBitmap(Vector3 position){
        Vector2Int p = new Vector2Int((int)position.x,(int)position.z);
        bool alone = true;
        if((int)position.z < Mathf.RoundToInt(Grid.current.ZSize) -1 && StreetManager.current[p.x,p.y+1]!= null){
            if (StreetManager.current[p.x,p.y+1].bitmap != 0 )
            {
                bitmap |= (int)StreetDirections.NORTH;
                alone = false; 
            }
        }
        if((int)position.x < Grid.current.XSize - 1 && StreetManager.current[p.x+1,p.y] != null){
            if(StreetManager.current[p.x+1,p.y].bitmap != 0 ){
                bitmap |= (int)StreetDirections.EAST;
                alone = false;
            }
        }
        if((int)position.z > 0 && StreetManager.current[p.x,p.y-1] != null){
            if(StreetManager.current[p.x,p.y-1].bitmap != 0 ){
                bitmap |= (int)StreetDirections.SOUTH;
                alone = false;
            }
        }
        if((int)position.x > 0 && StreetManager.current[p.x-1,p.y] != null){
            if(StreetManager.current[p.x-1,p.y].bitmap != 0 ){
                bitmap |= (int)StreetDirections.WEST;
                alone = false;
            }
        }

        GameEvents.current.StreetUpdateEvent(p);

        return alone;
    }


}
