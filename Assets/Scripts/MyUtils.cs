using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class MyUtils
    {
        public static void SetRotY(GameObject gameObject, float rotY)
        {
            Quaternion rot = gameObject.transform.localRotation;
            Vector3 rotE = rot.eulerAngles;
            rotE.y = rotY;
            rot.eulerAngles = rotE;
            gameObject.transform.localRotation = rot;
        }
    }
}
