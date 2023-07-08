using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBarCtrl : MonoBehaviour
{
    [SerializeField]
    private GameObject Internal;

    [SerializeField]
    private EntityBase entity;
    [SerializeField]
    private Camera cam;


    [SerializeField]
    private GameObject worldPointObj;

    void Update()
    {
        //ÏÔÊ¾
        Vector3 s = Internal.transform.localScale;
        s.x = entity.GetHPRate();
        Internal.transform.localScale = s;

        /**
        //¸úËæ
        Vector3 pos = worldPointObj.transform.position;
        
        Vector3 screenPos = Camera.main.WorldToScreenPoint(pos);

        transform.position = screenPos;
        **/

    }

    private void FixedUpdate()
    {
        //¸úËæ
        Vector3 pos = worldPointObj.transform.position;

        Vector3 screenPos = cam.WorldToScreenPoint(pos);

        transform.position = screenPos;
    }


}
