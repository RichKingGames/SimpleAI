using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RichKingGames.AI
{
    public class AIBehaviourMeleeAttack : AIBehaviour
    {
        public AIMeleeAttackDetector meleeDetector;

        [SerializeField]
        private bool isWaiting;
        [SerializeField]
        private float delay = 1;

        private void Awake()
        {
            if (meleeDetector == null)
                meleeDetector = transform.parent.GetComponentInParent<AIMeleeAttackDetector>();
        }
        public override void PerformAction(AIEnemy aIEnemy)
        {
            if(isWaiting)
                return;
            if(!meleeDetector.PlayerDetected)
                return;
            aIEnemy.CallAttack();
            isWaiting = true;
            StartCoroutine(AttackDelayCoroutine());
        }

        IEnumerator AttackDelayCoroutine()
        {
            yield return new WaitForSeconds(delay);
            isWaiting = false;
        }
    }
}