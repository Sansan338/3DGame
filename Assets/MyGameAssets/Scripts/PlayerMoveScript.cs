using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveScript : MonoBehaviour
{
    [SerializeField]
    Rigidbody playerRigidbody;
    [SerializeField]
    Animator playerAnimator;

    private float moveSpeed;
    [SerializeField]
    private float walkSpeed;
    [SerializeField]
    private float sprintSpeed;
    private Vector3 moveDirection;

    private float animSpeed = 1.0f;

    void Start()
    {
        //マウスカーソルを非表示
        Cursor.visible = false;
        //マウスカーソルを固定
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        //移動キー入力の取得
        float MoveX = Input.GetAxis("Horizontal");
        float MoveZ = Input.GetAxis("Vertical");

        if(MoveX != 0 || MoveZ != 0)
        {
            moveSpeed = walkSpeed;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                moveSpeed = sprintSpeed;
            }
        }
        else
        {
            moveSpeed = 0.0f;
        }

        //移動速度によってアニメーションを変更
        playerAnimator.SetFloat("Speed", moveSpeed);
        playerAnimator.speed = animSpeed;

        //進行方向
        moveDirection = new Vector3(MoveX, 0, MoveZ);
        //正規化
        moveDirection.Normalize();
        //移動
        playerRigidbody.AddRelativeForce(moveDirection * moveSpeed);

        float MouseX = Input.GetAxis("Mouse X");
        if(Mathf.Abs(MouseX) > 0.001f)
        {
            transform.RotateAround(transform.position, Vector3.up, MouseX);
        }
    }
}
