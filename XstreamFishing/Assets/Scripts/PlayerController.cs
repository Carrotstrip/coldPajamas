using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float turnSpeed = 1000f;
    public float accelerateSpeed = 1000f;
    public bool can_move;
    private Rigidbody rb;
    protected Vector2 move_vector;
    public Cannon cannon;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        can_move = true;
    }

    void OnMove(InputValue input)
    {
        move_vector = input.Get<Vector2>();
    }

    void OnRT() {
        cannon.Fire();
    }

    void OnLT() {
        cannon.gimbalingUp = true;
    }

    void OnLB() {
        cannon.gimbalingDown = true;
    }

    void OnLTUp() {
        cannon.gimbalingUp = false;
    }

    void OnLBUp() {
        cannon.gimbalingDown = false;
    }

    void Update()
    {
        if (can_move)
        {
            float moveHorizontal = move_vector.x;
            float moveVertical = move_vector.y;
            rb.AddTorque(0f, moveHorizontal * turnSpeed * Time.deltaTime, 0f);
            rb.AddForce(transform.forward * moveVertical * accelerateSpeed * Time.deltaTime);
        }
        else
        {
            rb.velocity = new Vector3(0, 0, 0);
        }
    }

    // void FixedUpdate()
    // {
    //     float moveHorizontal = Input.GetAxis ("Horizontal");
    //     float moveVertical = Input.GetAxis ("Vertical");
    //     float jump = 0.0f;

    //     if (Input.GetKeyDown("space") && onGround == true)
    //     {
    //         jump = jumpSpeed;
    //     }

    //     Vector3 movement = new Vector3(moveHorizontal, jump, moveVertical);
    //     rb.AddForce(movement * speed);
    // }

    //     void OnTriggerEnter(Collider other)
    // {
    //     if (other.gameObject.CompareTag ("Pick Up")){
    //         other.gameObject.SetActive(false);
    //         count += 1;
    //     }
    // }
    // void OnCollisionEnter(Collision other)
    // {
    //     if(other.gameObject.name == "Ground"){
    //         onGround = true;
    //     }
    // }
    // void OnCollisionExit(Collision other)
    // {
    //     if(other.gameObject.name == "Ground"){
    //         onGround = false;
    //     }
    // }


}
