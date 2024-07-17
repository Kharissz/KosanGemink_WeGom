using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Menyapu : MonoBehaviour
{
    private Animator anim;
    bool eKeyPressed;
    [SerializeField] float elapsedTime;
    float keyPressedTime;
    bool sapu=false;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();       
    }

    // Update is called once per frame
    void Update()
    {
        Sapu();        
    }

    void Sapu()
    {
        // Saat tombol 'e' ditekan
        if (Input.GetKeyDown(KeyCode.E))
        {
            eKeyPressed = true;
            keyPressedTime = Time.time;
        }

        // Saat tombol 'e' masih ditekan
        if (eKeyPressed && Input.GetKey(KeyCode.E))
        {
            sapu = true;

            // Hitung berapa lama tombol 'e' telah ditekan
            elapsedTime = Time.time - keyPressedTime;
            Debug.Log(elapsedTime);

            // Jika tombol 'e' ditekan selama 2 detik (misinya berhasil)
            if (elapsedTime >= 2f)
            {
                Debug.Log("Misi berhasil!");
                // Lakukan apa pun yang diperlukan saat misi berhasil
            }
        }

        // Saat tombol 'e' dilepas
        if (Input.GetKeyUp(KeyCode.E))
        {
            eKeyPressed = false;
            sapu = false;
            keyPressedTime = 0f;
            elapsedTime = 0f;
        }

        // Animasi Menyapu
        anim.SetBool("Menyapu", sapu);
    }
    
}
