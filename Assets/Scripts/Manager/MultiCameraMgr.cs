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

    public float smoothing = 0.15f;



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
        float ang = Vector3.SignedAngle(Vector3.right, Vec, Vector3.up);
        Vector3 Vec_ = new Vector3(Vec.x, Vec.y, Vec.z * 1.6666f);

        float lengh1 = Vec.magnitude;
        float lengh2 = Vec_.magnitude;

        if (lengh2 >= maxDistance)
        {
            print("AAAAAAAA");
            Vector3 v = Vec.normalized * maxDistance / 2 * lengh1 / lengh2;
            camA.setPosition(LookA + v);
            camB.setPosition(LookB - v);
        }
        else
        {
            camA.setPosition(LookCenter);
            camB.setPosition(LookCenter);
        }


        viwer.setAng(-ang+90);
    }
}
