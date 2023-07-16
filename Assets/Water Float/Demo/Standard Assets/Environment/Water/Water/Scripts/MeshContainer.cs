using UnityEngine;

public class MeshContainer : MonoBehaviour
{
    private Mesh mesh;

    private void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;
    }

    private void Update()
    {
        if (mesh != null)
        {
            // Recalculate mesh normals to ensure proper lighting
            mesh.RecalculateNormals();
        }
    }
}
