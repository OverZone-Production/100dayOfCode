using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheRPG.Core;
using TheRPG.Combat;

namespace TheRPG.Combat
{
    public class Level : MonoBehaviour
    {
        [SerializeField] int level = 1;
        [SerializeField] int curExp = 0;
        [SerializeField] int toNextLevel = 15;
        
        public void GainExp(int exp)
        {
            curExp += exp;
            if (curExp >= toNextLevel)
            {
                level++;
                GetComponent<Fighter>().DamageBoost(2);
                GetComponent<Health>().increaseHealthCap(10);
            }
        }
    }
}
