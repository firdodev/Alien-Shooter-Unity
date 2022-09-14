using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController characterController;

    public float runSpeed = 12f;
    public float gravity = -9.81f;
    public float jumpHight = 3f;

    public Transform groundCheck;
    public float groundDist = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Run();
    }

    private void Run()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position,groundDist,groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        characterController.Move(move * runSpeed * Time.deltaTime);

        Jump();

        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);

        if(Input.GetButtonDown("Fire3"))
        {
            runSpeed = 20f;
        }else if(Input.GetButtonUp("Fire3"))
        {
            runSpeed = 12f;
        }
    }

    private void Jump()
    {
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHight * -2f * gravity);
        }
    }
}
