using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankKnight : MonoBehaviour
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
        if (Input.GetKey(KeyCode.I))
        {
            print("i key is held down");
            transform.position +=
            transform.forward * speed * Time.deltaTime;
            animator.SetBool("isMoving", true);
        }
        if (Input.GetKey(KeyCode.K))
        {
            print("k key is held down");
            transform.position +=
            -transform.forward * speed * Time.deltaTime;
            animator.SetBool("isMoving", true);
        }
        if (Input.GetKey(KeyCode.J))
        {
            print("j key is held down");
            transform.Rotate(transform.up * -rotateSpeed * Time.deltaTime);
            animator.SetBool("isMoving", true);
        }
        if (Input.GetKey(KeyCode.L))
        {
            print("l key is held down");
            transform.Rotate(transform.up * rotateSpeed * Time.deltaTime);
            animator.SetBool("isMoving", true);
        }
        if (Input.GetKey(KeyCode.U))
        {
            print("attack");
        }
        if (Input.GetKey(KeyCode.O))
        {
            print("special ability");
        }
        if (!Input.anyKey)
        {
            animator.SetBool("isMoving", false);
        }
    }
}
