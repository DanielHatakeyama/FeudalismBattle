using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightMove : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;

    [Header("Movement Settings")]
    [SerializeField] float moveSpeed = 5f;
    int isMoving = 0;
    int moveDirectionInt = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown("d"))
        {
            moveDirection(moveSpeed, 0, 0);
        }
        else if (Input.GetKeyDown("a"))
        {
            moveDirection(-moveSpeed, 0, 1);
        }
        else if (Input.GetKeyDown("w"))
        {
            moveDirection(0, moveSpeed, 2);
        }
        else if (Input.GetKeyDown("s"))
        {
            moveDirection(0, -moveSpeed, 3);
        }
        else if (!Input.GetKey("a") && !Input.GetKey("d") && !Input.GetKey("w") && !Input.GetKey("s"))
        {
            moveDirection(0, 0, -1);
        }
    }

    void moveDirection(float x, float y, int moveDir)
    {
        //rb.velocity = new Vector2(x, y);
        if (moveDir >= 0)
            animator.SetInteger("MoveDirectionInt", moveDir);
        animator.SetFloat("Speed", Mathf.Sqrt(x * x + y * y) / moveSpeed);
    }
}
