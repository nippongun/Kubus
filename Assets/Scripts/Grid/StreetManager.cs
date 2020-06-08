using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StreetManager : MonoBehaviour
{
    [SerializeField]
    public int [,] streetTiles;

    private List<Street> streets;    
    public static StreetManager current;
    void Awake (){
        current = this;
        streets = new List<Street>();
    }

    void Start(){
        streetTiles = new int [Grid.current.gridArray.GetLength(0),Grid.current.gridArray.GetLength(2)];
    }

    public void AddStreetToArray(Vector2 position, int bit){
        streetTiles[(int)position.x, (int)position.y] = bit;
        Debug.Log("AddStreetToArray -  Point added at:" + position );
    }

    public int this[int i, int j]{
        get{
            return streetTiles[i,j];
        }
    }
}
