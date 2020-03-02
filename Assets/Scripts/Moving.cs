using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    private float minHeight;
    private CharacterController controller;
    private float verticalVelocity;
    private Vector3 moveVector;
    private Vector3 jumpVector;
    private float gravity = 14.0f;
    private float jumpForce = 10.0f;
    private bool canMove = true;
    public float speed = 1f;

    private Animator anim;

    public Vector3 rotation;
    // Start is called before the first frame update
    void Start()
    {

        //this.rotation = new Vector3(0, Input.GetAxisRaw("Horizontal") * 180 * Time.deltaTime, 0);
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        moveVector = new Vector3(0f, 0f, 10 * Input.GetAxis("Vertical") * Time.deltaTime);
        rotation.y = Input.GetAxisRaw("Horizontal") * 180 * Time.deltaTime;
        transform.Rotate(0f, rotation.y, 0f);

        if (controller.isGrounded)
        {
            verticalVelocity = -gravity * Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                verticalVelocity = jumpForce;
                anim.SetBool("Jump", true);
            }

        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;

        }
        jumpVector.y = verticalVelocity * Time.deltaTime;
        controller.Move(jumpVector * transform.localScale.y);

        if (canMove) { 
            controller.Move(Quaternion.AngleAxis(transform.eulerAngles.y, Vector3.up) * moveVector * transform.localScale.y* speed);
            anim.SetFloat("Speed", Input.GetAxisRaw("Vertical"));
        }
        else
        {
            anim.SetFloat("Speed", 0f);
        }   
    }
    private void LateUpdate()
    {
        anim.SetBool("Jump", false);
        minHeight = Terrain.activeTerrain.SampleHeight(transform.position);
        if ((!controller.isGrounded || verticalVelocity >= -0.5f) && transform.position.y < minHeight)
        {
            transform.position = new Vector3(transform.position.x, minHeight, transform.position.z);
        }
    }

    public void StopMovement()
    {
        canMove = false;
    }

}
