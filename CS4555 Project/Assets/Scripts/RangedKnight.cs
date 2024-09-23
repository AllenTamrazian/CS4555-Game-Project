using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedKnight : MonoBehaviour
{
    public int speed = 25;
    public int rotateSpeed = 180;
    private Animator animator;
    private Rigidbody rb;
    Transform swordOnBelt;
    Transform swordInHand;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        swordOnBelt = FindDeepChild(transform, "Item_SwordSheath");
        swordInHand = FindDeepChild(transform, "swordInHand");
    }

    Transform FindDeepChild(Transform parent, string name)
    {
        foreach (Transform child in parent)
        {
            if (child.name == name)
                return child;

            // Recursively search in this child's children
            Transform result = FindDeepChild(child, name);
            if (result != null)
                return result;
        }
        return null;  // Return null if not found
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
        if(Input.GetKey(KeyCode.R) & rb.velocity.magnitude==0)
        {
            print("attack");
            swordOnBelt.gameObject.SetActive(false);
            swordInHand.gameObject.SetActive(true);
            animator.SetBool("attackingIdle", true);
        }
        if (Input.GetKeyUp(KeyCode.R) & rb.velocity.magnitude == 0)
        {
            swordOnBelt.gameObject.SetActive(true);
            swordInHand.gameObject.SetActive(false);
            print("not attacking idle");
            animator.SetBool("attackingIdle", false);
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
