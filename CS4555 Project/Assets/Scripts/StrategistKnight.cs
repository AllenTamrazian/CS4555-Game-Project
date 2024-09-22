using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrategistKnight : MonoBehaviour
{
    public GameObject supportKnight;
    public GameObject defensiveKnight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            print("w key is held down");
            transform.position +=
            transform.forward * 5 * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            print("s key is held down");
            transform.position +=
            -transform.forward * 5 * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            print("a key is held down");
            transform.Rotate(transform.up * -180 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            print("d key is held down");
            transform.Rotate(transform.up * 180 * Time.deltaTime);
        }

        supportKnight.transform.position = transform.position - transform.right * 3;
        supportKnight.transform.rotation = Quaternion.Slerp(supportKnight.transform.rotation, transform.rotation, Time.deltaTime * 5);

        defensiveKnight.transform.rotation = Quaternion.Slerp(defensiveKnight.transform.rotation, transform.rotation, Time.deltaTime * 5);
        defensiveKnight.transform.position = transform.position - transform.right* -3;
    }
}
