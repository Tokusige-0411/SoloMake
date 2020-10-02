using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float speed_ = 3.0f;
        [SerializeField] private float jumpVec_ = 4.0f;
        private int dashCnt_ = 1;
        private float dashSpeed_ = 10.0f;
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
                float dashRad = Vector2.Angle(Vector2.zero, moveInput);
                Vector2 dashVec = new Vector2(dashSpeed_ * Mathf.Cos(dashRad), dashSpeed_ * Mathf.Sin(dashRad));
                return;
            }

            // 左右移動
            if (moveInput.x != 0)
            {
                rigidbody2D_.position += new Vector2(speed_ * moveInput.x, 0.0f) * Time.deltaTime;
            }

            // ｼﾞｬﾝﾌﾟ
            if (Input.GetButtonDown("Jump"))
            {
                if (isGround)
                {
                    rigidbody2D_.AddForce(Vector2.up * jumpVec_, ForceMode2D.Impulse);
                    isGround = false;
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            isGround = true;
            Debug.Log("接地した");
        }
    }
}
