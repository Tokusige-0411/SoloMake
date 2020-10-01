using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float moveForce_ = 10.0f;
    private float speed_ = 5.0f;
    private int key = 0;

    private Vector2 velocity_;

    private Rigidbody2D rigidbody2D_;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D_ = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");
        if(moveInput != 0)
        {
            rigidbody2D_.position += new Vector2(speed_ * moveInput, 0.0f) * Time.deltaTime;
        }
    }
}
