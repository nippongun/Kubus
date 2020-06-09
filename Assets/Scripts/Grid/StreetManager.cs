using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StreetManager : MonoBehaviour
{
    [SerializeField]
    public Street [,] streetTiles;

    private List<Street> streets;    
    public static StreetManager current;

    void Awake (){
        current = this;
        streets = new List<Street>();
    }

    void Start(){
        streetTiles = new Street [Grid.current.gridArray.GetLength(0),Grid.current.gridArray.GetLength(2)];
        GameEvents.current.onStreetUpdate += UpdateNeighbors;
    }

    public void AddStreetToArray(Vector2 position, int bit, Street street){
        streetTiles[(int)position.x, (int)position.y] = street;
        streetTiles[(int)position.x, (int)position.y].bitmap = bit;
        Debug.Log("AddStreetToArray -  Point added at:" + position );
    }

    public Street this[int i, int j]{
        get{
            return streetTiles[i,j];
        }
    }

    void UpdateNeighbors(Vector2Int p){
        Debug.Log(streetTiles.ToString());
        //Update the Northern neigbor
        
        if(p.y < Grid.current.ZSize -1){
                if(p.y < streetTiles.GetLength(1) && streetTiles[p.x,p.y+1]!=null ){
                // Update the South
                streetTiles[p.x,p.y+1].bitmap |= (int)StreetDirections.SOUTH;
                streetTiles[p.x,p.y+1].bitmap += (streetTiles[p.x,p.y+1].bitmap % 2 == 0 ? 0 : -1);
                Debug.Log("Update norther neighbor");
            }
        }
        if(p.y > 0 && streetTiles[p.x,p.y-1] != null){
            streetTiles[p.x,p.y-1].bitmap |= (int)StreetDirections.NORTH;
            streetTiles[p.x,p.y-1].bitmap += (streetTiles[p.x,p.y-1].bitmap % 2 == 0 ? 0 : -1);
        }
        if(p.x < Grid.current.XSize - 1){
            if(p.x < streetTiles.GetLength(0) && streetTiles[p.x+1,p.y] != null){
                streetTiles[p.x+1,p.y].bitmap |= (int)StreetDirections.WEST;
                streetTiles[p.x+1,p.y].bitmap  += (streetTiles[p.x+1,p.y].bitmap % 2 == 0 ? 0 : -1);
            }
        }
        if(p.x > 0 && streetTiles[p.x-1,p.y]!= null){
            streetTiles[p.x-1,p.y].bitmap |= (int)StreetDirections.EAST;
            streetTiles[p.x-1,p.y].bitmap += (streetTiles[p.x-1,p.y].bitmap % 2 == 0 ? 0 : -1);
        }   
    }
}
