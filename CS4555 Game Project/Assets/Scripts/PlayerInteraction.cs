using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public List<Transform> npcList;
    public List<Transform> objectList;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < npcList.Capacity; i += 1)
        {
            if (Vector3.Distance(transform.position, npcList[i].transform.position) < 2 & (Input.GetKey(KeyCode.U) | Input.GetKey(KeyCode.R) | Input.GetKey(KeyCode.Q)))
            {
                print("interacting with npc");
            }
        }
        for (int i = 0; i < objectList.Capacity; i += 1)
        {
            if (Vector3.Distance(transform.position, objectList[i].transform.position) < 2 & (Input.GetKey(KeyCode.U) | Input.GetKey(KeyCode.R) | Input.GetKey(KeyCode.Q)))
            {
                print("interacting with object");
            }
        }
    }
}
