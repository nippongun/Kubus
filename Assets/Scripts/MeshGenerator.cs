using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshGenerator : MonoBehaviour
{
    public Grid grid;
    Mesh mesh;

    Vector3[] vertices;
    int[] triangles;


    void Start(){       
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh  = mesh;
        CreateShape();
        grid = GetComponent<Grid>();
    }
    
    void Update(){
        UpdateMesh();
    }

    void CreateShape(){
        vertices = new Vector3[(grid.ZSize +1 ) * (grid.XSize +1)];

        for (int i = 0, z = 0; z <= grid.ZSize; z++)
        {
            for (int x = 0; x <= grid.XSize; x++)
            {
                vertices[i] = new Vector3(x*grid.CellSize,0,z*grid.CellSize);
                i++;
            }
        }

        triangles = new int[grid.XSize * grid.ZSize * 6];

        int vert = 0;
        int tris = 0;
        for (int z = 0; z < grid.ZSize; z++)
        {
            for (int x = 0; x < grid.XSize; x++)
            {
                triangles[0 + tris] = vert + 0;
                triangles[1 + tris] = vert + grid.XSize + 1;
                triangles[2 + tris] = vert + 1;
                triangles[3 + tris] = vert + 1;
                triangles[4 + tris] = vert + grid.XSize + 1;
                triangles[5 + tris] = vert + grid.XSize + 2;

                vert++;
                tris += 6;
            }    
            vert++;        
        }
    }

    void UpdateMesh(){
        mesh.Clear();

        mesh.vertices = vertices;
        mesh.triangles = triangles;

        mesh.RecalculateNormals();
        mesh.RecalculateBounds();

        MeshCollider meshCollider = gameObject.GetComponent<MeshCollider>();
        meshCollider.sharedMesh = mesh;
    }

    private void OnDrawGizmos(){
        if(Time.timeScale > 0){
            Gizmos.color = Color.red;

            for (int x = 0; x < vertices.Length; x++)
            {
                Gizmos.DrawSphere(vertices[x],10f);
            }
        }
    }
}
