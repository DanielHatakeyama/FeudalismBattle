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
        if (Time.time % 4000f < 1000f)
        {
            transform.position += new Vector3(0, speed * Time.deltaTime, 0);
            animator.SetInteger("MoveDirectionInt", 0);
        }
        else if (Time.time % 4000f < 2000f)
        {
            transform.position -= new Vector3(0, speed * Time.deltaTime, 0);
            animator.SetInteger("MoveDirectionInt", 1);
        }
        else if (Time.time % 4000f < 3000f)
        {
            transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
            animator.SetInteger("MoveDirectionInt", 2);
        }
        else
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
            animator.SetInteger("MoveDirectionInt", 3);
        }
    }
}
