using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundVolumeControl : MonoBehaviour
{
    public Transform playerTransform; // Transform dari player atau objek yang menjadi pendengar
    private AudioSource audioSource;
    [SerializeField] private Slider musik;
    private float distance;
    public float maxVolumeDistance = 10f; // Jarak maksimum di mana suara akan terdengar maksimal
    public float minVolumeDistance = 1f; // Jarak minimum di mana suara akan terdengar minimal

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
        if (playerTransform == null)
        {
            // Jika playerTransform tidak ditetapkan, gunakan posisi kamera sebagai default
            playerTransform = Camera.main.transform;
        }

        audioSource.Play();
    }

    void Update()
    {
        if (audioSource != null && playerTransform != null)
        {
            
            // Hitung jarak antara player dan sumber suara
            if(transform.position.x > playerTransform.position.x)
            distance = Vector2.Distance(transform.position,playerTransform.position);
            else if(transform.position.x < playerTransform.position.x)
            distance = Vector2.Distance(playerTransform.position,transform.position);
           


            // Hitung volume berdasarkan jarak dengan fungsi Attenuation
            float volume = musik.value - Mathf.Clamp01((distance - minVolumeDistance) / (maxVolumeDistance - minVolumeDistance));
            volume = Mathf.Clamp01(volume); // Pastikan volume tidak melebihi 1 atau kurang dari 0

            // Atur volume AudioSource
            audioSource.volume = volume;
        }
    }
}
