using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterAnimations playerAnimations;
    private Rigidbody rb;
    private float walkSpeed = 2f , zSpeed = 1.5f , rotationY = -90f; //, rotationSpeed = 15f;

    void Awake()
    {
        playerAnimations = GetComponentInChildren<CharacterAnimations>();
        rb = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        RotatePlayer();
        AnimatePlayerWalk();
    }
    void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        rb.velocity = new Vector3(Input.GetAxisRaw("Horizontal") * -walkSpeed, rb.velocity.y, Input.GetAxisRaw("Vertical") * -zSpeed);
    }

    void RotatePlayer()
    {
        if(Input.GetAxisRaw("Horizontal") > 0)
        {
            transform.rotation = Quaternion.Euler(0f, -Mathf.Abs(rotationY), 0f);
        }
        else if(Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.rotation = Quaternion.Euler(0f, Mathf.Abs(rotationY), 0f);
        }
    }

    void AnimatePlayerWalk(){
        if(Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            playerAnimations.Walk(true);
        }
        else
        {
            playerAnimations.Walk(false);
        }
    }
}
