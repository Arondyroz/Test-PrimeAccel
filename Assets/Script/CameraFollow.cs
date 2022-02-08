using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace PrimeAcceleratorClone
{
    public class CameraFollow : MonoBehaviour
    {
        public Transform targetPlayer;

        [SerializeField] private float smoothSpeed;
        [SerializeField] private Vector3 offset;
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            CameraFollowPlayer();
        }

        void CameraFollowPlayer()
        {
            Vector3 cameraPos = targetPlayer.position + offset;
            Vector3 smoothedPos = Vector3.Lerp(transform.position, cameraPos, smoothSpeed * Time.deltaTime);
            transform.position = smoothedPos;
        }
    }
}
