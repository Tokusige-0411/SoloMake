using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float speed_ = 3.0f;
        [SerializeField] private float jumpVec_ = 4.0f;
        private int dashCnt_ = 20;
        private float dashSpeed_ = 20.0f;
        private Vector2 dashVec_;
        private bool isGround;
        private PlayerState plState_;

        private Rigidbody2D rigidbody2D_;

        // Start is called before the first frame update
        void Start()
        {
            rigidbody2D_ = GetComponent<Rigidbody2D>();
            isGround = true;
            plState_ = PlayerState.Idle;
        }

        // Update is called once per frame
        void Update()
        {
            Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

            // ﾀﾞｯｼｭ(ﾀﾞｯｼｭ中は移動とかできないようにする)
            if (Input.GetButtonDown("Dash"))
            {
                if (plState_ != PlayerState.Dash)
                {
                    float dashRad = Mathf.Atan2(moveInput.y, moveInput.x);
                    dashVec_ = new Vector2(dashSpeed_ * Mathf.Cos(dashRad), dashSpeed_ * Mathf.Sin(dashRad));
                    plState_ = PlayerState.Dash;
                }
            }
            if (plState_ == PlayerState.Dash)
            {
                if(dashCnt_ > 0)
                {
                    rigidbody2D_.position += dashVec_ * Time.deltaTime;
                    dashCnt_--;
                    return;
                }
                else
                {
                    plState_ = PlayerState.Idle;
                    dashCnt_ = 20;
                }
            }

            // 左右移動
            if (moveInput.x != 0)
            {
                rigidbody2D_.position += new Vector2(speed_ * moveInput.x, 0.0f) * Time.deltaTime;
            }

            // ｼﾞｬﾝﾌﾟ
            if (isGround)
            {
                if (Input.GetButtonDown("Jump"))
                {
                    rigidbody2D_.velocity = Vector2.zero;
                    rigidbody2D_.AddForce(Vector2.up * jumpVec_, ForceMode2D.Impulse);
                    isGround = false;
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(!isGround)
            {
                isGround = true;
                Debug.Log("接地した");
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            plState_ = PlayerState.Idle;
            dashCnt_ = 20;
        }
    }
}
