using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollUV : MonoBehaviour
{
    MeshRenderer mesh;
    public float parallax = 2f;
    private void Start()
    {
        mesh = GetComponent<MeshRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        Material mat = mesh.material;
        Vector2 offset = mat.mainTextureOffset;
        offset.y += Time.deltaTime / 10f / parallax; //divide to slow scrolling //TODO MAGIQUE NUmber
        mat.mainTextureOffset = offset;
    }
}
