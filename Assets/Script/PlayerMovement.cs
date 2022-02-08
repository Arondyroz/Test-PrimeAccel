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

        // Update is called once per frame
        void Update()
        {
            UpdateMovePlayer();
        }

        void UpdateMovePlayer()
        {
            MovePlayer();
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                playerInput = PlayerInput.LeftMove;
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                playerInput = PlayerInput.RightMove;
            }

            if(Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
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
                    break;
                case PlayerInput.LeftMove:
                    anim.SetBool("B_Run", true);
                    rb.velocity = new Vector3(-moveSpeed * Time.deltaTime, 0f, 0f);
                    //transform.Translate(new Vector3(1 * moveSpeed * Time.deltaTime, 0, 0));
                    if (transform.rotation.y != 270f)
                    {
                        transform.rotation = Quaternion.Euler(0, 270f, 0);
                    }
                    break;
                case PlayerInput.RightMove:
                    anim.SetBool("B_Run", true);
                    rb.velocity = new Vector3(moveSpeed * Time.deltaTime, 0f, 0f);
                    //transform.Translate(new Vector3(1 * -moveSpeed * Time.deltaTime, 0, 0));
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
