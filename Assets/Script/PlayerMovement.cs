using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PrimeAcceleratorClone
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float moveSpeed;

        private Animator anim;
        private Rigidbody rb;
        // Start is called before the first frame update
        void Start()
        {
            anim = GetComponent<Animator>();
            rb = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void Update()
        {
            MovePlayer();
        }

        private void FixedUpdate()
        {
            
        }

        void MovePlayer()
        {
            if(Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                anim.SetBool("B_Run", true);
            }

        }
    }
}
