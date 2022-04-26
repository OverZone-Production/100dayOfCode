using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheRPG.Combat;

namespace TheRPG.Combat 
{ 
    public class specialMove : MonoBehaviour
    {
        [SerializeField] int MP = 50;
        [SerializeField] int maxMP = 50;
        private int baseAttack;
        void Update()
        {
            Slot1();
        }

        public void GainMP(int gained)
        {
            MP += gained;
            if (MP > maxMP)
            {
                MP = maxMP;
            }
        }
       

        private void Slot1()
        {
            if (Input.GetButtonDown("Slot1"))
            {
                MP -= 10;
                print("::");
                BoostAttack();
                Invoke("ResetAttack", 10);
            }
        }
        private void BoostAttack()
        {
            GetComponent<Fighter>().DamageBoost(10);
        }

        private void ResetAttack()
        {
            GetComponent<Fighter>().DamageBoost(-10);
        }

    }
}