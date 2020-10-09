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
        private PlayerState plState_;
        private bool isGround;
        private bool isHide;

        delegate void MoveParts(Vector2 moveInput);
        private Dictionary<PlayerState, MoveParts> moveList_;

        private GameObject light2D_;
        private Rigidbody2D rigidbody2D_;
        private Collider2D collider2D_;

        // Start is called before the first frame update
        void Start()
        {
            plState_ = PlayerState.Normal;
            moveList_ = new Dictionary<PlayerState, MoveParts>();
            moveList_.Add(PlayerState.Normal, Normal);
            moveList_.Add(PlayerState.Hide, Hide);
            isGround = true;
            isHide = false;
            light2D_ = GameObject.Find("Light");
            collider2D_ = GetComponent<CapsuleCollider2D>();
            rigidbody2D_ = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            moveList_[plState_](moveInput);

            // 光に当たっているかどうか
            Vector2 up = new Vector2(transform.position.x, transform.position.y + collider2D_.bounds.size.y / 2.0f);
            Vector2 down = new Vector2(transform.position.x, transform.position.y - collider2D_.bounds.size.y / 2.0f);
            RaycastHit2D upHit = Physics2D.Raycast(up, (Vector2)light2D_.transform.position - up, Vector2.Distance(up, light2D_.transform.position));
            RaycastHit2D downHit = Physics2D.Raycast(down, (Vector2)light2D_.transform.position - down, Vector2.Distance(down, light2D_.transform.position));
            isHide = (upHit.collider.gameObject.name != "Light") && (downHit.collider.gameObject.name != "Light");
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!isGround)
            {
                isGround = true;
                Debug.Log("接地した");
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            //dashReset();
        }

        private void dashReset()
        {
            rigidbody2D_.velocity = Vector2.zero;
            plState_ = PlayerState.Normal;
            dashCnt_ = 20;
        }

        private void Normal(Vector2 moveInput)
        {
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

            // 背景の影に入る
            if(isHide)
            {
                if(Input.GetButtonDown("Hide"))
                {
                    rigidbody2D_.velocity = Vector2.zero;
                    rigidbody2D_.gravityScale = 0.0f;
                    plState_ = PlayerState.Hide;
                }
            }

            //// ﾀﾞｯｼｭ(ﾀﾞｯｼｭ中は移動とかできないようにする)
            //if (Input.GetButtonDown("Dash"))
            //{
            //    if (plState_ != PlayerState.Dash)
            //    {
            //        float dashRad = Mathf.Atan2(moveInput.y, moveInput.x);
            //        dashVec_ = new Vector2(dashSpeed_ * Mathf.Cos(dashRad), dashSpeed_ * Mathf.Sin(dashRad));
            //        plState_ = PlayerState.Dash;
            //    }
            //}
            //if (plState_ == PlayerState.Dash)
            //{
            //    if (dashCnt_ > 0)
            //    {
            //        rigidbody2D_.position += dashVec_ * Time.deltaTime;
            //        dashCnt_--;
            //        return;
            //    }
            //    else
            //    {
            //        dashReset();
            //    }
            //}
        }

        private void Hide(Vector2 moveInput)
        {
            // 影状態解除
            if(Input.GetButtonDown("Hide") || (!isHide))
            {
                rigidbody2D_.gravityScale = 1.0f;
                plState_ = PlayerState.Normal;
            }

            // 上下左右移動
            if (moveInput != Vector2.zero)
            {
                rigidbody2D_.position += new Vector2(speed_ * moveInput.x, speed_ * moveInput.y) * Time.deltaTime;
            }

            // ｼﾞｬﾝﾌﾟ
            if (Input.GetButtonDown("Jump"))
            {
                plState_ = PlayerState.Normal;
                rigidbody2D_.gravityScale = 1.0f;
                rigidbody2D_.velocity = Vector2.zero;
                rigidbody2D_.AddForce(Vector2.up * jumpVec_, ForceMode2D.Impulse);
                isGround = false;
            }
        }
    }
}
