using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PrefabDictionary : MonoBehaviour
{
    // A dictionary should exist only once per game, thus a singleton.
    private static PrefabDictionary instance = null;
    public static PrefabDictionary Instance {get { return instance; } }

    [SerializeField]
    private BuildingBlockType[] allBuildingBlockTypes;

    [HideInInspector]
    //public Dictionary<int, BuildingBlock> buildingBlockDictionary = new Dictionary<int, BuildingBlock>();
    public List<BuildingBlock> buildingBlockDictionary = new List<BuildingBlock>();
    void Awake()
    {
        if (instance != null && instance !=this)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad( this.gameObject );
        for (int i = 0; i < allBuildingBlockTypes.Length; i++)
        {
            BuildingBlockType bbt = allBuildingBlockTypes[i];
            BuildingBlock buildingBlock = new BuildingBlock(i,bbt.blockName,bbt.prefab);
            buildingBlockDictionary.Insert(i,buildingBlock);
            Debug.Log("Block added to dictionary " + buildingBlockDictionary[i].blockName);
        }
    }
}

public class BuildingBlock{
    public int blockID;
    public string blockName;
    public GameObject blockPrefab;
    public BuildingBlock(int blockID, string blockName, GameObject blockPrefab){
        this.blockID = blockID;
        this.blockName = blockName;
        this.blockPrefab = blockPrefab;
    }
}

[Serializable]
public struct BuildingBlockType{
    public string blockName;
    public GameObject prefab;
}
