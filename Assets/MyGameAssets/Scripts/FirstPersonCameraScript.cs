using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCameraScript : MonoBehaviour
{
    private float underLimit = 65.0f;
    private float upperLimit = -90.0f;

    private Vector3 firstPersonCamera;
    private Vector3 offset;

    [SerializeField]
    Transform myTransform;
    [SerializeField]
    GameObject player;

    void Start()
    {
        //マウスカーソルを非表示
        Cursor.visible = false;
        //マウスカーソルを固定
        Cursor.lockState = CursorLockMode.Locked;

        firstPersonCamera = myTransform.localEulerAngles;
    }

    void Update()
    {
        float MouseX = Input.GetAxis("Mouse X");
        if (Mathf.Abs(MouseX) > 0.001f)
        {
            transform.RotateAround(transform.position, Vector3.up, MouseX);
        }
        //マウスのY軸移動量を取得
        float MouseY = Input.GetAxis("Mouse Y");

        var x = firstPersonCamera.y - MouseY;

        if (x <= underLimit && x >= upperLimit)
        {
            firstPersonCamera.y = x;
            myTransform.localEulerAngles = firstPersonCamera;
        }
    }
}
