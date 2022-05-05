using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
	public float lookRadius = 10f;  // Detection range for player

	public GameObject target;   // Reference to the player
	public CharacterStat targetStats;
	NavMeshAgent agent; // Reference to the NavMeshAgent
	CharacterCombat combat;


	// Use this for initialization
	void Start()
	{
		agent = GetComponent<NavMeshAgent>();
		combat = GetComponent<CharacterCombat>();
	}

	// Update is called once per frame
	void Update()
	{
		// Distance to the target
		float distance = Vector3.Distance(target.transform.position, transform.position);

		// If inside the lookRadius
		if (distance <= lookRadius)
		{
			// Move towards the target
			agent.SetDestination(target.transform.position);

			// If within attacking distance
			if (distance <= agent.stoppingDistance)
			{
				if (targetStats != null)
				{
					combat.Attack(targetStats);
				}

				FaceTarget();   // Make sure to face towards the target
			}
		}
	}

	// Rotate to face the target
	void FaceTarget()
	{
		Vector3 direction = (target.transform.position - transform.position).normalized;
		Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
		transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
	}

	// Show the lookRadius in editor
	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, lookRadius);
	}

}
