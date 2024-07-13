using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectingGarbage : MonoBehaviour
{
    public GameObject[] trashes;
    public float jumlahSampah;
    public float sampahSekarang = 0;
    public float Distance = 1f;
    public LayerMask trash;

    public ObjectHold script;
    // Start is called before the first frame update
    void Start()
    {
        trashes = GameObject.FindGameObjectsWithTag("sampah");        
    }

    // Update is called once per frame
    void Update()
    {
        CheckSampah();
        if(sampahSekarang == jumlahSampah)
        {
            Debug.Log("Sampah sudah penuh");
            this.enabled = false;
        }        
    }

    void CheckSampah()
    {
        if(trashes == null)
        trashes = null;

        if(Physics.CheckSphere(transform.position,Distance,trash))
        {
            sampahSekarang+=1;
            for(int i = 0; i < trashes.Length; i++)
            {
                if(script.hit.transform.name == trashes[i].name)
                {
                    Destroy(trashes[i]);
                }
                
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, Distance);
    }
}
