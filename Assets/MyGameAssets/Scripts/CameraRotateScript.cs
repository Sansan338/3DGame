using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CameraRotateScript : MonoBehaviour
{
    private float underLimit = 65.0f;
    private float upperLimit = -90.0f;

    private Vector3 mainCamera;
    [SerializeField]
    Transform myTransform;

    private void Start()
    {
        mainCamera = myTransform.localEulerAngles;
    }

    void Update()
    {
        //ƒ}ƒEƒX‚ÌYŽ²ˆÚ“®—Ê‚ðŽæ“¾
        float MouseY = Input.GetAxis("Mouse Y");

        var x = mainCamera.y - MouseY;

        if(x <= underLimit && x >= upperLimit)
        {
            mainCamera.y = x;
            myTransform.localEulerAngles = mainCamera;
        }
    }
}
