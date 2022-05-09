using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheRPG.Combat;
using TheRPG.Core;

namespace TheRPG.Combat
{
    public class DropExp : MonoBehaviour
    {
        [SerializeField] Level level;
        [SerializeField] int amountOfExp = 15;
        void Update()
        {
            if (GetComponent<Health>().GetIsDead())
            {
                level.GainExp(amountOfExp);
                amountOfExp = 0;
            }
        }
    }
}

