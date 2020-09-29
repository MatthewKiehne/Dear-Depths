using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour {

    [SerializeField]
    private CharacterController controller;

    private float jumpHeight = 2f;

    [SerializeField]
    private Transform groundCheck;
    private float groundDistance = .4f;
    public LayerMask groundMask;

    private float speed = 4;
    private float gravity = -19.6f;

    [SerializeField]
    private Vector3 velocity = Vector3.zero;

    private bool isGrounded;

    private void Update() {

        this.isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0) {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = (this.transform.right * x) + (this.transform.forward * z);

        controller.Move(move * this.speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded) {
            velocity.y = Mathf.Sqrt(this.jumpHeight * -2f * this.gravity);
        }

        velocity.y += (this.gravity * Time.deltaTime);

        controller.Move(velocity * Time.deltaTime);

    }
}
