using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TheRPG.Controller;
using System;

public class LabController : MonoBehaviour
{
    [SerializeField] WayPoints wayPoint;
    [SerializeField] float wayPointsTolerance = 1f;

    int curWayPointIndex = 0;

    Vector3 robotPos;
    // Start is called before the first frame update
    void Start()
    {
        robotPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        robotPos = transform.position;
        UpdateAnimator();
        WayPointsBehaviour();
    }

    private void WayPointsBehaviour()
    {
        Vector3 nextPos = robotPos;
        if (wayPoint != null)
        {
            if (isAtWayPoint())
            {
                moveNextWayPoint(); // Move to the next waypoint
            }
            nextPos = GetCurrentWayPoint();
        }

        GetComponent<NavMeshAgent>().destination = nextPos;
    }

    private void moveNextWayPoint()
    {
        
        curWayPointIndex = wayPoint.GetNextIndex(curWayPointIndex);
    }

    private void UpdateAnimator()
    {
        Vector3 velocity = GetComponent<NavMeshAgent>().velocity;
        Vector3 localVelocity = transform.InverseTransformDirection(velocity);
        float speed = localVelocity.z;
        GetComponent<Animator>().SetFloat("forwardSpeed", speed);
    }

    private bool isAtWayPoint()
    {
        Vector3 currentWayPoint = GetCurrentWayPoint();
        float distanceToWaypoint = Vector3.Distance(robotPos, currentWayPoint);
        return distanceToWaypoint < wayPointsTolerance;
    }

    private Vector3 GetCurrentWayPoint()
    {
        return wayPoint.GetPoint(curWayPointIndex);
    }
}



