using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedKnight : MonoBehaviour
{
    public int speed = 25;
    public int rotateSpeed = 180;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.T))
        {
            print("t key is held down");
            transform.position +=
            transform.forward * speed * Time.deltaTime;
            animator.SetBool("isMoving", true);
        }
        if (Input.GetKey(KeyCode.G))
        {
            print("g key is held down");
            transform.position +=
            -transform.forward * speed * Time.deltaTime;
            animator.SetBool("isMoving", true);
        }
        if (Input.GetKey(KeyCode.F))
        {
            print("f key is held down");
            transform.Rotate(transform.up * -rotateSpeed * Time.deltaTime);
            animator.SetBool("isMoving", true);
        }
        if (Input.GetKey(KeyCode.H))
        {
            print("h key is held down");
            transform.Rotate(transform.up * rotateSpeed * Time.deltaTime);
            animator.SetBool("isMoving", true);
        }
        if(Input.GetKey(KeyCode.R))
        {
            print("attack");
        }
        if (Input.GetKey(KeyCode.Y))
        {
            print("special ability");
        }
        if (!Input.anyKey)
        {
            animator.SetBool("isMoving", false);
        }
    }
}
