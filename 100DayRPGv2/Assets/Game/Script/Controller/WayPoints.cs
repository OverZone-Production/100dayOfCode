using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheRPG.Controller
{
    public class WayPoints : MonoBehaviour
    {
        const float radius = 0.5f;

        private void OnDrawGizmos()
        {
            for (int i=0; i<transform.childCount; i++)
            {
                int nextIdx = GetNextIndex(i);
                Gizmos.DrawSphere(GetPoint(i), radius);
                Gizmos.DrawLine(GetPoint(i), GetPoint(nextIdx));
            }
        }

        public int GetNextIndex(int idx)
        {
            if (idx+1 == transform.childCount)
            {
                return 0;
            }
            return idx + 1;
        }

        public Vector3 GetPoint(int idx)
        {
            return transform.GetChild(idx).position;
        }
    }
}
