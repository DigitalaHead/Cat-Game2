using UnityEngine;

public class BackgroundClip : MonoBehaviour
{
    public MeshRenderer backgroundRenderer;
    public float clipDistance;

    void Update()
    {
        float distance = Vector3.Distance(transform.position, backgroundRenderer.transform.position);
        float alphaCutoff = Mathf.Clamp01(distance / clipDistance);
        backgroundRenderer.material.SetFloat("_AlphaCutoff", alphaCutoff);
    }
}
