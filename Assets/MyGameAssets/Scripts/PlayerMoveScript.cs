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
        //�}�E�X�J�[�\�����\��
        Cursor.visible = false;
        //�}�E�X�J�[�\�����Œ�
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        //�ړ��L�[���͂̎擾
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

        //�ړ����x�ɂ���ăA�j���[�V������ύX
        playerAnimator.SetFloat("Speed", moveSpeed);
        playerAnimator.speed = animSpeed;

        //�i�s����
        moveDirection = new Vector3(MoveX, 0, MoveZ);
        //���K��
        moveDirection.Normalize();
        //�ړ�
        playerRigidbody.AddRelativeForce(moveDirection * moveSpeed);

        float MouseX = Input.GetAxis("Mouse X");
        if(Mathf.Abs(MouseX) > 0.001f)
        {
            transform.RotateAround(transform.position, Vector3.up, MouseX);
        }
    }
}
