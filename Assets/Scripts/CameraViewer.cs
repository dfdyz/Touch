using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraViewer : MonoBehaviour
{
    [SerializeField]
    private Material material;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setAng(float rad)
    {
        material.SetFloat("_Ang", rad);
    }
}
