using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PrimeAcceleratorClone
{
    public class Plane : MonoBehaviour
    {
        [SerializeField] private RotatingPlane plane1;
        [SerializeField] private RotatingPlane plane2;
        // Start is called before the first frame update
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                if (gameObject.CompareTag("Plane1"))
                    plane1.isOnPanel = true;
                if (gameObject.CompareTag("Plane2"))
                    plane2.isOnPanel = true;
            }

        }
        private void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                if (collision.gameObject.CompareTag("Player"))
                {
                    if (gameObject.CompareTag("Plane1"))
                        plane1.isOnPanel = false;

                    if (gameObject.CompareTag("Plane2"))
                        plane2.isOnPanel = false;
                }

            }
        }
    }
}
