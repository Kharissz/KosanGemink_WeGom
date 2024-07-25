using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mengelap : MonoBehaviour
{
    public Collider col;
    private Animator anim;
    public Membersihkan cleaning;
    [SerializeField] private float jumlah;
    public float dibersihkan;
    public bool pegangLap = false;
    public bool beresLap = false;
    public bool sekali = false;
    bool ngelap;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        col = GetComponent<Collider>();
        col.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if(pegangLap)
        {
            if(Input.GetKey(KeyCode.E) && cleaning.script.debu)
            {ngelap = true;}
            else
            {ngelap = false;}
            Animasi();
        }

        if(jumlah == dibersihkan)
        {
            Debug.Log("Beres Mengelap");
            beresLap=true;
        }

    }

    void Animasi()
    {
        anim.SetBool("Mengelap", ngelap);
    }
}
