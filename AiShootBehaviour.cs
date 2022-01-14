using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RichKingGames.AI
{
    public class AiShootBehaviour : AIBehaviour
    {
        public AIPlayerDetector playerDetector;

        [SerializeField]
        private bool isWaiting;
        [SerializeField]
        private float delay = 1;

        public override void PerformAction(AIEnemy aIEnemy)
        {
            if (isWaiting == true)
                return;
            if(playerDetector.playerDetected)
            {
                isWaiting = true;
                aIEnemy.CallOnMovement(playerDetector.directionToTarget);
                aIEnemy.CallAttack();
                StartCoroutine(AttackDelayCoroutine());
            }
        }

        private IEnumerator AttackDelayCoroutine()
        {
            yield return new WaitForSeconds(delay);
            isWaiting = false;
        }
    }
}