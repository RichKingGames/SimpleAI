using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RichKingGames.AI
{
    public class AIPlayerDetector : MonoBehaviour
    {
        public bool playerDetected { get; private set; }
        private GameObject target;

        public LayerMask detectorLayerMask;
        public Transform detectorOrigin;
        public Vector2 directionToTarget => target.transform.position - detectorOrigin.position;
        public GameObject Target
        {
            get => target;
            private set 
            {
                target = value;
                playerDetected = target != null;
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(detectorLayerMask.Contains(collision.gameObject.layer))
            {
                Target = collision.gameObject;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (detectorLayerMask.Contains(collision.gameObject.layer))
            {
                Target = null;
            }
        }

    }
}