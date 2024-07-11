using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectingGarbage : MonoBehaviour
{
    public float jumlahSampah;
    public float sampahSekarang = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(sampahSekarang == jumlahSampah)
        {
            Debug.Log("Sampah sudah penuh");
        }        
    }

    void OnTriggerEnter(Collider coll)
    {
        if(coll.CompareTag("sampah"))
        {
            sampahSekarang += 1;
            Debug.Log("Sampah sudah " + sampahSekarang + " buah");
            // Destroy(coll.gameObject);
        }
    }
}
