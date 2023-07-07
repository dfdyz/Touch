using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiCameraMgr : MonoBehaviour
{
    [SerializeField]
    private CameraAccessor camA;
    [SerializeField]
    private CameraAccessor camB;
    [SerializeField]
    private CameraViewer viwer;

    [SerializeField]
    private float maxDistance = 14;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 LookA = camA.getLookAtPosition();
        Vector3 LookB = camB.getLookAtPosition();

        Vector3 LookCenter = (LookA + LookB)/2;

        Vector3 Vec = LookB - LookA;

        float lengh = Vec.magnitude;

        if (lengh >= maxDistance)
        {
            
        }
        else
        {

        }




    }
}
