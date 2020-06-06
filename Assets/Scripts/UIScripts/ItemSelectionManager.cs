using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSelectionManager : MonoBehaviour
{

    public GameObject itemSelectionTile;
    private int itemCount;
    private List<GameObject> items = new List<GameObject>();
    void Start()
    {
        itemCount = PrefabDictionary.Instance.buildingBlockDictionary.Count;
        InstantiateItems();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InstantiateItems(){
        for (int i = 0; i < itemCount; i++)
        {
            GameObject gameObject;
            gameObject = Instantiate(itemSelectionTile,transform.parent);
            items.Add(gameObject);
            gameObject.transform.SetParent(this.transform);
        }
    }
}
