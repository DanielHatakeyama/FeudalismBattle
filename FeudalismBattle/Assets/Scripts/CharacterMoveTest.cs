using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMoveTest : MonoBehaviour
{
    public float speed;
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        print(Time.time);
        if (Time.time % 8f < 2f)
        {
            transform.position += new Vector3(0, speed * Time.deltaTime, 0);
            animator.SetInteger("MoveDirectionInt", 2);
        }
        else if (Time.time % 8f < 4f)
        {
            transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
            animator.SetInteger("MoveDirectionInt", 1);
        }
        else if (Time.time % 8f < 6f)
        {
            transform.position -= new Vector3(0, speed * Time.deltaTime, 0);
            animator.SetInteger("MoveDirectionInt", 3);
        }
        else
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
            animator.SetInteger("MoveDirectionInt", 0);
        }
    }
}
