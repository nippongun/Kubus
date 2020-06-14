using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StreetManager : MonoBehaviour
{
    [SerializeField]
    public Street [,] streets;
 
    public static StreetManager current;
    
    [SerializeField]
    private StreetTile[] streetTiles;
    void Awake (){
        current = this;
    }

    void Start(){
        streets = new Street [Grid.current.gridArray.GetLength(0),Grid.current.gridArray.GetLength(2)];
        GameEvents.current.onStreetUpdate += UpdateNeighbors;
    }

    public void AddStreetToArray(Vector2 position, int bit, Street street){
        streets[(int)position.x, (int)position.y] = street;
        streets[(int)position.x, (int)position.y].bitmap = bit;
        Debug.Log("AddStreetToArray -  Point added at:" + position );
    }

    public Street this[int i, int j]{
        get{
            return streets[i,j];
        }
    }

    void UpdateNeighbors(Vector2Int p){
        Debug.Log(streets.ToString());
        //Update the Northern neigbor
        
        if(p.y < Grid.current.ZSize -1){
                if(p.y < streets.GetLength(1) && streets[p.x,p.y+1]!=null ){
                // Update the South
                streets[p.x,p.y+1].bitmap |= (int)StreetDirections.SOUTH;
                streets[p.x,p.y+1].bitmap += (streets[p.x,p.y+1].bitmap % 2 == 0 ? 0 : -1);
                UpdateMaterial(p + Vector2Int.up);
            }
        }
        if(p.y > 0 && streets[p.x,p.y-1] != null){
            streets[p.x,p.y-1].bitmap |= (int)StreetDirections.NORTH;
            streets[p.x,p.y-1].bitmap += (streets[p.x,p.y-1].bitmap % 2 == 0 ? 0 : -1);
            UpdateMaterial(p + Vector2Int.down);
        }
        if(p.x < Grid.current.XSize - 1){
            if(p.x < streets.GetLength(0) && streets[p.x+1,p.y] != null){
                streets[p.x+1,p.y].bitmap |= (int)StreetDirections.WEST;
                streets[p.x+1,p.y].bitmap  += (streets[p.x+1,p.y].bitmap % 2 == 0 ? 0 : -1);
                UpdateMaterial(p + Vector2Int.right);
            }
        }
        if(p.x > 0 && streets[p.x-1,p.y]!= null){
            streets[p.x-1,p.y].bitmap |= (int)StreetDirections.EAST;
            streets[p.x-1,p.y].bitmap += (streets[p.x-1,p.y].bitmap % 2 == 0 ? 0 : -1);
            UpdateMaterial(p + Vector2Int.left);
        }   
    }

    void UpdateMaterial(Vector2Int p){
        streets[p.x,p.y].GetComponent<MeshRenderer>().material = streetTiles[(streets[p.x,p.y].bitmap == 1 ? 1 : streets[p.x,p.y].bitmap / 2)].material;
    }
}
