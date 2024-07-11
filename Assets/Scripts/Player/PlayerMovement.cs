using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    private Rigidbody rb;
    public float speed = 12f;
    [SerializeField] float gravity = 9.8f * 2f;
    [SerializeField] float jumpHeight = 3f;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance = .4f;
    public LayerMask groundMask;

    Vector3 velocity;

    bool isGrounded;
    bool isMoving;

    private Vector3 lastposition = new Vector3(0f,0f,0f);
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        // rb = GetComponent<Rigidbody>();       
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        // Ground Check
        isGrounded = Physics.CheckSphere(groundCheck.position,groundDistance,groundMask);

        // Resetting the default velocity
        if(isGrounded && velocity.y < 0f)
        {
            velocity.y = -2f;
        }

        // Get Input Axis
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Creating the moving vector
        Vector3 move = transform.right * x + transform.forward * z; //(right -> red axis, foward -> blue axis)

        // Move the Player
        controller.Move(move * speed * Time.deltaTime);

        // Check if the player jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            // Going Up
            velocity.y = MathF.Sqrt(jumpHeight * 2f * gravity);
        }

        // Falling down
        velocity.y -= gravity * Time.deltaTime;

        // Executing the Jump
        controller.Move(velocity * Time.deltaTime);

        if(lastposition != gameObject.transform.position && isGrounded)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        lastposition = gameObject.transform.position;
    }

        void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(groundCheck.position, groundDistance);
    }
}
