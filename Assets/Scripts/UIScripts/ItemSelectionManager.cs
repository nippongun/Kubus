using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    GameObject itemSelectionTile;
    private int itemCount;
    void Start()
    {
        itemCount = PrefabDictionary.Instance.buildingBlockDictionary.Count;


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
