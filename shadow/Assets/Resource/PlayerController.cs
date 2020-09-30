using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed_ = 1.0f;
    private Vector2 force_;
    private Rigidbody2D rigidbody2D_;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D_ = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        force_ = new Vector2(0.0f, 0.0f, 0.0f);
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            force_ = new Vector2(-(speed_), 0.0f, 0.0f);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            force_ = new Vector2(speed_, 0.0f, 0.0f);
        }
        rigidbody2D_.AddForce(force_);
    }
}
