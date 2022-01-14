using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RichKingGames.AI
{
    public class AIStaticEnemyBrain : AIEnemy
    {
        public AIBehaviour attachBehaviour;

        private void Update()
        {
            attachBehaviour.PerformAction(this);
        }
    }
}