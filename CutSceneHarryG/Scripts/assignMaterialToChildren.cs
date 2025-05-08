using UnityEngine;

public class AssignMaterialToChildren : MonoBehaviour
{
    public Material newMaterial;

    void Start()
    {
        MeshRenderer[] renderers = GetComponentsInChildren<MeshRenderer>();
        foreach (MeshRenderer renderer in renderers)
        {
            renderer.material = newMaterial;
        }
    }
}
