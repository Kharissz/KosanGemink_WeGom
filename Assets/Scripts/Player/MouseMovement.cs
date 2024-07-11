using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    [SerializeField] private Transform playerBody;
    [SerializeField] float mouseSensi = 10f;
    float xRotation = 0f;
    float yRotation = 0f;

    [SerializeField] float topClamp = -90f;
    [SerializeField] float bottomClamp = 90f;

    // Start is called before the first frame update
    void Start()
    {
        // Biar kursor mouse gk keliatan in game
        Cursor.lockState = CursorLockMode.Locked;        
    }

    // Update is called once per frame
    void Update()
    {
        // Input Mouse
        float mouseX = Input.GetAxis("Mouse X") * mouseSensi * Time.deltaTime; 
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensi * Time.deltaTime;

        // Rotasi terhadap sumbu x (melihat atas/bawah)
        xRotation -= mouseY;

        // Clamp the rotation
        xRotation = Mathf.Clamp(xRotation,topClamp,bottomClamp);

        // Rotasi terhadap sumbu y (melihat kiri/kanan)
        // yRotation += mouseX;

        // Menerapkan rotasi ke transform
        transform.localRotation = Quaternion.Euler(xRotation,yRotation,0f);
        playerBody.Rotate(Vector3.up * mouseX);  
    }
    
}
