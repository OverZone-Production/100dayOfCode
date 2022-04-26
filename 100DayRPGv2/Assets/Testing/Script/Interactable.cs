using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
