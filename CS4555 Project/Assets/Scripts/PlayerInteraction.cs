using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public List<Transform> npcList;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //for npc in npcList:
        //    if (Vector3.Distance(transform.position, npc) < 2)
        //    {
        //        print("interacting with npc");
        //    }
        if (Input.GetKeyDown(KeyCode.R))
        {
            float interactRange = 2f;
            Collider[] colliderArray = Physics.OverLapSphere(transform.position, interactRange);
            foreach (Collider collider in colliderArray)
            {
                if (collider.TryGetComponent(out NPCInteractable npcInteractable))
                {
                    npcInteractable.Interact();
                }
            }
        }
    }
}
