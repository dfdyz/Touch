using System;
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

    public void setAng(float ang)
    {
        material.SetFloat("_Ang", (ang / 180 * Mathf.PI));
    }
}
