using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Membersihkan : MonoBehaviour
{
    public Raycasting script;
    public ObjectHold hold;
    public Menyapu sapu;
    public Mengelap lap;
    [SerializeField] float elapsedTime;
    bool eKeyPressed;
    float keyPressedTime;

    bool dekat = false;
    [SerializeField] bool pegang = false;
    public bool bersihkan = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PegangBenda();
        Bersihkan();
        LepasBenda();

        // Jika Selesai Menyapu
        if(sapu.beresSapu && !sapu.sekali)
        {
            // Nonaktifkan Menyapu
            hold.Drop();
            pegang = false;
            sapu.sekali = true;
            sapu.pegangSapu = false;
            sapu.gameObject.SetActive(false);
        }

        // Jika Selesai Mengelap
        if(lap.beresLap && !lap.sekali)
        {
            // Nonaktifkan Mengelap
            hold.Drop();
            pegang = false;
            lap.sekali = true;
            lap.pegangLap = false;
            lap.gameObject.SetActive(false);
        }

        // Jika beres keduanya
        if(sapu.beresSapu && lap.beresLap)
        {
            // Nonaktifkan Membersihkan
            this.enabled=false;
        }
    }
    
    void Bersihkan()
    {
        // Saat tombol 'e' ditekan
        if (Input.GetKeyDown(KeyCode.E))
        {
            eKeyPressed = true;
            keyPressedTime = Time.time;
        }

        // Saat tombol 'e' masih ditekan
        if (eKeyPressed && Input.GetKey(KeyCode.E) && script.debu)
        {
            bersihkan = true;

            // Hitung berapa lama tombol 'e' telah ditekan
            elapsedTime = Time.time - keyPressedTime;
            Debug.Log(elapsedTime);


            // Jika tombol 'e' ditekan selama 2 detik (misinya berhasil)
            if (elapsedTime >= 2f)
            {
                if(script.hitInfo.collider.gameObject.tag == "debuSapu")
                {
                    sapu.dibersihkan+=1;
                    script.hitInfo.collider.gameObject.SetActive(false);
                } 
                else if(script.hitInfo.collider.gameObject.tag == "debuLap")
                {
                    lap.dibersihkan+=1;
                    script.hitInfo.collider.gameObject.SetActive(false);
                }

            }
        }

        // Saat tombol 'e' dilepas
        if (Input.GetKeyUp(KeyCode.E))
        {
            eKeyPressed = false;
            bersihkan = false;
            keyPressedTime = 0f;
            elapsedTime = 0f;
        }
    }

    void PegangBenda()
    {
        if(!pegang)
        {
            if(dekat && Input.GetKeyDown(KeyCode.E) && script.hitInfo.transform.name == "Lap")
            {
                pegang = true;
                lap.pegangLap = true;
            }
            if(dekat && Input.GetKeyDown(KeyCode.E) && script.hitInfo.transform.name == "Sapu")
            {
                pegang = true;
                sapu.pegangSapu = true;
            }
        }

    }

    void LepasBenda()
    {
        if(pegang)
        {
            if(Input.GetKeyDown(KeyCode.Q))
            {
                pegang = false;
                dekat = false;
                sapu.pegangSapu = false;
                lap.pegangLap = false;
            }    

        }
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.CompareTag("alat"))
        {
            dekat =true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if(col.CompareTag("alat"))
        {
            dekat = false;
        }
    }
}
