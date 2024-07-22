using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycasting : MonoBehaviour
{
    [SerializeField] private Transform rayPoint;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float rayLength = 20f;
    public new Camera camera;
    public RaycastHit hitInfo;
    public bool debu = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        debu = false;

       if (Physics.Raycast(ray, out hitInfo, rayLength, layerMask))
       {
            // Debug.Log("Hit " + hitInfo.collider);
            // Debug.DrawRay(rayPoint.position,transform.TransformDirection(Vector3.forward) * hitInfo.distance, Color.green);
            Debug.DrawRay(ray.origin, ray.direction * rayLength, Color.yellow);
            Debug.Log(hitInfo.transform.name);
            if(hitInfo.transform.tag == "debuSapu" || hitInfo.transform.tag == "debuLap")
            {debu = true;}

       }
       else 
       {
            // Debug.Log("Hit Nothing");
            // Debug.DrawRay(rayPoint.position,transform.TransformDirection(Vector3.forward) * hitInfo.distance, Color.yellow);
            Debug.DrawRay(ray.origin, ray.direction * rayLength, Color.green);
       }     
    }
}
