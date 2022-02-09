using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PrimeAcceleratorClone
{
    public class RotatingPlane : MonoBehaviour
    {
        [SerializeField] private float speedRotate;
        private Transform player;
        private void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        }
        // Update is called once per frame

        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                //if (PlayerMovement.instance.playerInput == PlayerMovement.PlayerInput.LeftMove)
                //{
                //    transform.Rotate(0, 0, Time.deltaTime * -speedRotate, Space.Self);
                //}
                //else if (PlayerMovement.instance.playerInput == PlayerMovement.PlayerInput.RightMove)
                //{
                //    transform.Rotate(0, 0, Time.deltaTime * speedRotate, Space.Self);
                //}
                RotatePlane();
            }
        }

        void RotatePlane()
        {
            Vector3 lookDir = player.position - transform.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.back);
        }
    }
}
