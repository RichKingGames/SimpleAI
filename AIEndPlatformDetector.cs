using System;
using System.Collections;
using UnityEngine;

namespace RichKingGames.AI
{
    public class AIEndPlatformDetector : MonoBehaviour
    {
        public BoxCollider2D detectorCollider;

        public LayerMask groundMask;
        public float groundRaycastLength = 2;

        [Range(0, 1)]
        public float groundRaycastDelay = 0.1f; 
        
        public bool PathBlocked { get; private set; }

        public event Action OnPathBlocked;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            OnPathBlocked?.Invoke();
        }

        private void Start()
        {
            StartCoroutine(CheckGroundCoroutine());
        }

        private IEnumerator CheckGroundCoroutine()
        {
            yield return new WaitForSeconds(groundRaycastDelay);
            var hit = Physics2D.Raycast(detectorCollider.bounds.center, Vector2.down, groundRaycastLength, groundMask);
            if(hit.collider==null)
            {
                OnPathBlocked?.Invoke(); 
            }
            PathBlocked = hit.collider == null;
            StartCoroutine(CheckGroundCoroutine());
        }
    }

    
}