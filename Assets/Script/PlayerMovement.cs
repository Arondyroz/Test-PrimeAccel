using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PrimeAcceleratorClone
{
    public class PlayerMovement : MonoBehaviour
    {
        public static PlayerMovement instance;
        public PlayerInput playerInput;
        public enum PlayerInput
        {
            Idle,
            LeftMove,
            RightMove,
        }

        [SerializeField] private float moveSpeed;
        private bool leftClick, rightClick, idle;
        private Animator anim;
        private Rigidbody rb;
        // Start is called before the first frame update
        private void Awake()
        {
            if (instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                instance = this;
            }
        }
        void Start()
        {
            anim = GetComponent<Animator>();
            rb = GetComponent<Rigidbody>();
            playerInput = PlayerInput.Idle;
        }



        private void FixedUpdate()
        {
            float x = Input.GetAxis("Horizontal");
            float moveDir = x * moveSpeed * Time.fixedDeltaTime;
            rb.velocity = new Vector3(moveDir, 0f, 0f);
            UpdateMovePlayer();
        }

        void UpdateMovePlayer()
        {
            MovePlayer();
            if (rb.velocity.x < 0)
            {
                playerInput = PlayerInput.LeftMove;
            }

            if (rb.velocity.x > 0)
            {
                playerInput = PlayerInput.RightMove;
            }

            if(rb.velocity.x == 0)
            {
                playerInput = PlayerInput.Idle;
            }

        }
        void MovePlayer()
        {
       
            switch(playerInput)
            {
                case PlayerInput.Idle:
                    anim.SetBool("B_Run", false);
                    idle = true;
                    break;
                case PlayerInput.LeftMove:
                    anim.SetBool("B_Run", true);
                    //rb.velocity = new Vector3(-moveSpeed * Time.fixedDeltaTime, 0f, 0f);
                    if (transform.rotation.y != 270f)
                    {
                        transform.rotation = Quaternion.Euler(0, 270f, 0);
                    }
                    break;
                case PlayerInput.RightMove:
                    anim.SetBool("B_Run", true);
                    //rb.velocity = new Vector3(moveSpeed * Time.fixedDeltaTime, 0f, 0f);
                    if (transform.rotation.y != 90f)
                    {
                        transform.rotation = Quaternion.Euler(0, 90f, 0);
                    }
                    break;
                default:
                    break;
            }
        }


    }
}
