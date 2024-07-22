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
    private float jumpPower;
    [SerializeField]
    private float walkSpeed;
    [SerializeField]
    private float sprintSpeed;
    [SerializeField]
    private float backMagnification;

    private Vector3 moveDirection;

    private bool isGround;

    private float animSpeed = 1.0f;

    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        //移動キー入力の取得
        float MoveX = Input.GetAxis("Horizontal") * Time.deltaTime;
        float MoveZ = Input.GetAxis("Vertical") * Time.deltaTime;

        //移動速度確認
        if (MoveX != 0 || MoveZ != 0)
        {
            moveSpeed = walkSpeed;
            //Shiftを押していたらダッシュ
            if (Input.GetKey(KeyCode.LeftShift))
            {
                moveSpeed = sprintSpeed;
            }

            //後ろ向き移動減速補正
            if(Input.GetKey(KeyCode.S))
            {
                moveSpeed *= backMagnification;
            }
        }
        else
        {
            moveSpeed = 0.0f;
        }

        //進行方向
        moveDirection = new Vector3(MoveX, 0, MoveZ);
        //正規化
        moveDirection.Normalize();
        //移動
        playerRigidbody.AddRelativeForce(moveDirection * moveSpeed);
    }

    void Update()
    {
        //移動速度によってアニメーションを変更
        playerAnimator.SetFloat("Speed", moveSpeed);
        playerAnimator.speed = animSpeed; 

        if (Input.GetKeyDown(KeyCode.Space) && isGround == true)
        {
            playerRigidbody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            playerAnimator.SetBool("isJump",true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            playerAnimator.SetBool("isJump", false);
            isGround = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isGround = false;
        }
    }
}
