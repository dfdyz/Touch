using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAccessor : MonoBehaviour
{
    [SerializeField]
    private Camera _camera;
    [SerializeField]
    private GameObject lookAt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setFov(float ang)
    {
        _camera.fieldOfView = ang;
    }
    public Vector3 getLookAtPosition() {
        return lookAt.transform.position;
    }
}
