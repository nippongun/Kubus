using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleCubePlacer : MonoBehaviour
{
    private Grid grid;
    [SerializeField]
    private GameObject cubePrefab;
    private int blockSelectCounter = 0;
    void Awake(){
        grid = FindObjectOfType<Grid>();
    }

    void Update(){

        if(Input.GetMouseButtonDown(1)){
            RaycastHit hitInfo;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hitInfo))
            {
                Debug.Log(hitInfo.point + " --- " + hitInfo.normal);
                if(hitInfo.point.x <= grid.Height && hitInfo.point.z <= grid.Width){
                    PlaceCubeNear(hitInfo.point+ (hitInfo.normal/grid.CellSize));
                }
            }
        }
        if(Input.GetKeyDown(KeyCode.G)){
            blockSelectCounter++;
            if(blockSelectCounter >= PrefabDictionary.Instance.buildingBlockDictionary.Count) blockSelectCounter = 0;
        }
    }

    private void PlaceCubeNear(Vector3 nearPoint){
        Vector3 finalPosition = grid.GetNearestPointOnGrid(nearPoint) + new Vector3(grid.CellSize/2f,grid.CellSize/2f,grid.CellSize/2f);
        BuildingBlock bb = PrefabDictionary.Instance.buildingBlockDictionary[blockSelectCounter];
        GameObject cube = Instantiate(bb.blockPrefab,finalPosition,Quaternion.identity);
    }
}
