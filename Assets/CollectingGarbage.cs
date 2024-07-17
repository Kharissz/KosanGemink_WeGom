using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectingGarbage : MonoBehaviour
{
    [SerializeField] private GameObject sampah;
    public float jumlahSampah;
    public float sampahSekarang = 0;
    bool masuk = false;

    public ObjectHold script;
    // Start is called before the first frame update
    void Start()
    {

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

        if(masuk && Input.GetKeyDown(KeyCode.Q))
        {
            sampahSekarang+=1;
            // sampah.transform.position = transform.position;
            Destroy(sampah);
            sampah = null;
        }
    }

    void OnTriggerEnter(Collider coll)
    {
        if(coll.CompareTag("sampah"))
        {
            Debug.Log("MASUK");
            masuk = true;
            sampah = coll.gameObject;

        }
    }

    void OnTriggerExit(Collider coll)
    {
        if(coll.CompareTag("sampah"))
        {
            Debug.Log("KELUAR");
            masuk = false;
        }
    }
}
