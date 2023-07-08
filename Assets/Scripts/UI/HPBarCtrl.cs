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
    private GameObject worldPointObj;

    void Update()
    {
        //��ʾ
        Vector3 s = Internal.transform.localScale;
        s.x = entity.GetHPRate();
        Internal.transform.localScale = s;

        //����
        Vector3 pos = worldPointObj.transform.position;
        
        Vector3 screenPos = Camera.main.WorldToScreenPoint(pos);

        transform.position = screenPos;


    }
}
