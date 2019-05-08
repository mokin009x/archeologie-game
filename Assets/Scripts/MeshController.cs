using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]

public class MeshController : MonoBehaviour
{

    public Material mat;

    public Resolution resolution;
    
    private Mesh _mesh;

    private MeshFilter _meshFilter;

    private MeshRenderer _meshRenderer;
    // Start is called before the first frame update
    void Start()
    {
        resolution.
        _meshFilter = GetComponent<MeshFilter>();
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateMesh()
    {
        _mesh = new Mesh();
        
        List<Vector3> vertices = new List<Vector3>();
        List<int> triangles = new List<int>();
 
        Vector3[] face = new Vector3[] {
            new Vector3(0, 0, 0),
            new Vector3(1, 0, 0),
            new Vector3(1, 1, 0),
            new Vector3(0, 1, 0)
        };
 
        for (uint x = 0; x < terrainSize.x; x++)
        {
            for (uint y = 0; y < terrainSize.y; y++)
            {
                Vector3[] currentFace = new Vector3[] {
                    new Vector3(0 + x, 0 + y, 0),
                    new Vector3(1 + x, 0 + y, 0),
                    new Vector3(1 + x, 1 + y, 0),
                    new Vector3(0 + x, 1 + y, 0)
                };
 
                vertices.Add(currentFace[0]);
                vertices.Add(currentFace[1]);
                vertices.Add(currentFace[2]);
                vertices.Add(currentFace[3]);
 
                triangles.Add(0 + (int)x * (int)y);
                triangles.Add(1 + (int)x * (int)y);
                triangles.Add(2 + (int)x * (int)y);
                triangles.Add(0 + (int)x * (int)y);
                triangles.Add(2 + (int)x * (int)y);
                triangles.Add(3 + (int)x * (int)y);
            }
        }
 
        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();
        
        
        mf.mesh = mesh;
        mesh.RecalculateBounds();
        mesh.RecalculateNormals();
        
    }
}
