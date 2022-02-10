using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PrimeAcceleratorClone
{
    public class RotatingPlane : MonoBehaviour
    {
        public bool isOnPanel;
        public GameObject panelStand;
        public GameObject panelOther;

        private GameObject player;
        private float min = 0f;
        private float max = 180f;
        // Update is called once per frame
        private void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        void Update()
        {
            float diff = (player.transform.position.x - transform.position.x) * 180;
            float angle = diff;
            angle = Mathf.Clamp(diff, min, max);
            if (isOnPanel == false)
            {
                transform.eulerAngles = (Vector3.forward * angle);
                panelStand.transform.parent = gameObject.transform;
            }
            else
            {
                panelStand.transform.parent = null;
                gameObject.transform.position = panelOther.transform.position;
            }
        }
    }
}
