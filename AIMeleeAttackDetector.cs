using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace RichKingGames.AI
{
    public class AIMeleeAttackDetector : MonoBehaviour
    {
        public bool playerDetected { get; private set; }

        public LayerMask targetLayer;
        public float radius = 1;

        public UnityEvent<GameObject> OnPlayerDetected;

        private void Update()
        {
            Collider2D collider = Physics2D.OverlapCircle(transform.position, radius, targetLayer);
            playerDetected = collider != null;
            if (playerDetected)
                OnPlayerDetected?.Invoke(collider.gameObject);
        }
    }
}