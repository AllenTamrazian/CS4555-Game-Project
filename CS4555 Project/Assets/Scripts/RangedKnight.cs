using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedKnight : MonoBehaviour
{
    public int speed = 25;
    public int rotateSpeed = 180;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.T))
        {
            print("t key is held down");
            transform.position +=
            transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.G))
        {
            print("g key is held down");
            transform.position +=
            -transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.F))
        {
            print("f key is held down");
            transform.Rotate(transform.up * -rotateSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.H))
        {
            print("h key is held down");
            transform.Rotate(transform.up * rotateSpeed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.R))
        {
            print("attack");
        }
        if (Input.GetKey(KeyCode.Y))
        {
            print("special ability");
        }
    }
}
