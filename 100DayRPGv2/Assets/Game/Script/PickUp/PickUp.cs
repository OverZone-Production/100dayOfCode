using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheRPG.Core;
using TheRPG.Combat;

namespace TheRPG.PickUp
{
    public class PickUp : MonoBehaviour
    {
        [SerializeField] Health health;
        private void HideObject()
        {
            gameObject.SetActive(false);
        }

        void Update()
        {
           if(GetComponent<Health>().GetIsDead())
            {
                health.gainHealth(10);
                HideObject();
            }
        }


    }
}
