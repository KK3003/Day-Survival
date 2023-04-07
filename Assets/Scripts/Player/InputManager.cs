using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public delegate void MoveForward();
    public static event MoveForward OnMoveForward;

    public delegate void MoveBackward();
    public static event MoveForward OnMoveBackward;

    public delegate void RotateLeft();
    public static event RotateLeft OnRotateLeft;

    public delegate void RotateRight();
    public static event RotateRight OnRotateRight;

    public delegate void ShootBullet();
    public static event RotateRight OnShootBullet;

    public delegate void Jump();
    public static event Jump OnJump;

    public delegate void PickUP();
    public static event Jump OnPickUp;

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            if (OnMoveForward != null)
            {
                OnMoveForward();
            }
        }

        if (Input.GetKey(KeyCode.S))
        {
            if (OnMoveBackward != null)
            {
                OnMoveBackward();
            }
        }

        if (Input.GetKey(KeyCode.A))
        {
            if (OnRotateLeft != null)
            {
                OnRotateLeft();
            }
        }

        if (Input.GetKey(KeyCode.D))
        {
            if (OnRotateRight != null)
            {
                OnRotateRight();
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (OnShootBullet != null)
            {
                OnShootBullet();
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (OnJump != null)
            {
                OnJump();
            }
        }
    }
}
