using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class Combat : BaseCombat
    {
        public Score score;
        public GUI gui;
        public Health health;
        
        protected override void Update()
        {
            if (health.IsDead)
                Die();
        }
        public override void TakeDmg(int dmg)
        {
            base.TakeDmg(dmg);
            gui.UpdateHealth(health);
        }
    }
}