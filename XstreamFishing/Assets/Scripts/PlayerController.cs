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
}
