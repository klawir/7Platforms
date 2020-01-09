using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class Combat : BaseCombat
    {
        private void Start()
        {
            health.UpdateGUI();
        }
        protected override void Update()
        {
            if (health.IsDead)
                Die();
        }
        public override void TakeDmg(int dmg)
        {
            base.TakeDmg(dmg);
            health.UpdateGUI();
        }
    }
}