using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float turnSpeed = 1000f;
    public float accelerateSpeed = 1000f;
    public bool can_move;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        can_move = true;
    }
    void Update()
    {
        if (can_move)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
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
