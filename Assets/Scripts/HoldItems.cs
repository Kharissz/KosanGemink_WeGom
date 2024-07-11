using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHold : MonoBehaviour
{
    public GameObject Object;
    public Transform PlayerTransform;
    public float range = 2f;
    // public float Go = 100f;
    public Camera Camera;
    public bool isHolding =false;


    void Start()
    {
        
    }

    void Update()
    {

        if(Input.GetKeyDown(KeyCode.F))
        {
            StartPickUp();
        }
        if (Input.GetKeyDown(KeyCode.E) && isHolding)
        Drop();
        
    }

    void StartPickUp ()
    {

        RaycastHit hit;
        if (Physics.Raycast(Camera.transform.position, Camera.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            PickUp();
            isHolding = true;

        }

        // if(Input.GetKeyDown(KeyCode.E) && isHolding)
        // {
        //     isHolding = true;
        //     Drop();
        // }
    }

    void PickUp ()
    {
        // Gun.GetComponent<Rigidbody>().isKinematic = true;
        Object.transform.SetParent(PlayerTransform);
    }

    void Drop ()
    {
        isHolding = false;
        PlayerTransform.DetachChildren();
        // Gun.GetComponent<Rigidbody>().isKinematic = false;
    }
    
}
