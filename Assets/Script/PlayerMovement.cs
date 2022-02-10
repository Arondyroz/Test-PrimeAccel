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
        [SerializeField] private float accelerationSpeed;
        private bool accelerration;
        private float initialSpeed;
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
            initialSpeed = moveSpeed;
        }



        private void FixedUpdate()
        {
            float x = Input.GetAxis("Horizontal");
            float moveDir = x * moveSpeed * Time.fixedDeltaTime;
            if (accelerration == false)
            {
                rb.velocity = new Vector3(moveDir, 0f, 0f);
                moveSpeed = initialSpeed;
            }
            else
            {
                rb.velocity = new Vector3(moveDir, 0f, 0f);
                if (x != 0) moveSpeed += Time.deltaTime * accelerationSpeed;
                if (x == 0) moveSpeed = 0;
                if (moveSpeed > initialSpeed) moveSpeed = initialSpeed;
                if (moveSpeed <= 0) moveSpeed = 0;
            }

            if (rb.velocity.x != 0)
            {
                anim.SetFloat("run_multi", moveSpeed / initialSpeed);
            }
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

        public void acceleration(bool value)
        {
            accelerration = value;
            moveSpeed = 0;
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
                    if (transform.rotation.y != 270f)
                    {
                        transform.rotation = Quaternion.Euler(0, 270f, 0);
                    }
                    break;
                case PlayerInput.RightMove:
                    anim.SetBool("B_Run", true);
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
