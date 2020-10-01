using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float maxSpeed_ = 2.0f;
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
        float speed = Mathf.Abs(rigidbody2D_.velocity.x);
        if(speed < maxSpeed_)
        {

        }
    }
}
