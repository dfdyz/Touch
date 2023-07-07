using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAccessor : MonoBehaviour
{
    [SerializeField]
    private Camera _camera;
    [SerializeField]
    private GameObject lookAt;

    //private Vector3 targetPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = Vector3.Lerp(transform.position, targetPos, Managers.Instance.MultiCameraMgr.smoothing);
    }

    public void setFov(float ang)
    {
        _camera.fieldOfView = ang;
    }

    public void setPosition(Vector3 pos)
    {
        transform.position = pos;
    }
    public Vector3 getLookAtPosition() {
        return lookAt.transform.position;
    }
}
