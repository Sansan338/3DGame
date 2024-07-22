using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class FirstPersonCameraRotateScript : MonoBehaviour
{
    private float underLimit = 65.0f;
    private float upperLimit = -90.0f;

    private Vector3 firstPersonCamera;
    [SerializeField]
    Transform myTransform;

    private void Start()
    {
        firstPersonCamera = myTransform.localEulerAngles;
    }

    void Update()
    {
        //�}�E�X��Y���ړ��ʂ��擾
        float MouseY = Input.GetAxis("Mouse Y");

        var x = firstPersonCamera.y - MouseY;

        if(x <= underLimit && x >= upperLimit)
        {
            firstPersonCamera.y = x;
            myTransform.localEulerAngles = firstPersonCamera;
        }
    }
}
