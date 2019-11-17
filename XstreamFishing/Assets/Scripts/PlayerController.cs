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
    public GameObject shopUI;
    protected Vector2 move_vector;
    public Cannon cannon;
    public bool can_fly;
    private bool up;
    private float initial_y_pos;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        can_move = true;
        up = false;
        initial_y_pos = transform.position.y;
    }

    void OnSail(InputValue input)
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
            if(can_fly){
                if(up){
                    transform.Translate((Vector3.up*6f) * Time.deltaTime, Space.World);
                }
                else{
                    if(transform.position.y > initial_y_pos){
                        transform.Translate(Vector3.down * 10f * Time.deltaTime, Space.World);
                    }
                }
            }
        }
        else
        {
            rb.velocity = new Vector3(0, 0, 0);
        }
    }

    void OnA(){
        up = true;
    }

    void OnAUp(){
        up = false;
    }

    void OnB(){
        if(!can_move && shopUI.activeSelf){
            can_move = true;
            shopUI.SetActive(!shopUI.activeSelf);
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

    void OnTriggerEnter(Collider coll){
        GameObject obj = coll.gameObject;
        Debug.Log("Triggered: " + obj);
        if(obj.tag == "Beach"){
            Debug.Log("Triggered 2");
            can_move = false;
            shopUI.SetActive(!shopUI.activeSelf);
        }
    }


}
