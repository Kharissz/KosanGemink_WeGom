using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Menyapu : MonoBehaviour
{
    public Membersihkan cleaning;
    private Animator anim;
    [SerializeField] private float jumlah;
    public float dibersihkan;
    public bool pegangSapu = false;
    public bool beresSapu = false;
    public bool sekali = false;
    bool nyapu = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();       
    }

    // Update is called once per frame
    void Update()
    {
        if(pegangSapu)
        {
            if(Input.GetKey(KeyCode.E) && cleaning.script.debu)
            {nyapu = true;}
            else
            {nyapu = false;}
            Animasi();
        }

        if(jumlah == dibersihkan)
        {
            Debug.Log("Beres Menyapu");
            beresSapu=true;
        }

    }

    void Animasi()
    {
        anim.SetBool("Menyapu", nyapu);
    }
    
}
