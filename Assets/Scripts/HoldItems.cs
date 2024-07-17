using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHold : MonoBehaviour
{

    private GameObject Object;
    private Collider coll;
    public Transform PlayerTransform;
    public float range = 2f;
    // public float Go = 100f;
    public Camera Camera;
    public bool isHolding = false;
    public RaycastHit hit;


    void Start()
    {

    }

    void Update()
    {

        if(Input.GetKeyDown(KeyCode.E) && !isHolding)
        {
            StartPickUp();
        }
        if (Input.GetKeyDown(KeyCode.Q) && isHolding)
        Drop();
        
    }

    void StartPickUp ()
    {
        if (Physics.Raycast(Camera.transform.position, Camera.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            if (hit.transform.tag == "sampah")
            {
                Object = hit.transform.gameObject;
                coll = Object.GetComponent<Collider>();

                PickUp();
            }

        }
    }

    void PickUp ()
    {

        Object.transform.position = PlayerTransform.position;
        Object.transform.SetParent(PlayerTransform);
        // coll.enabled = false; 
        
        isHolding = true;
    }

    void Drop ()
    {
        // coll.enabled = true;
        PlayerTransform.DetachChildren();
        isHolding = false;
    }

    // void OnTriggerEnter(Collider col)
    // {
    //     if(col.CompareTag("sampah"))
    //     {Debug.Log("Menyentuh" + col.name);}
    // }
    
}
