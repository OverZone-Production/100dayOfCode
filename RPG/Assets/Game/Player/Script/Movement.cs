using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    Ray lastRay;
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            //lastRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            MoveToPosition();
        }

        UpdateAnimator();

        //Debug.DrawRay(lastRay.origin, lastRay.direction * 100);
    }

    private void UpdateAnimator()
    {
        Vector3 velocity = GetComponent<NavMeshAgent>().velocity;

        // Global to Local
        Vector3 localVelocity = transform.InverseTransformDirection(velocity);

        float speed = localVelocity.z;
        GetComponent<Animator>().SetFloat("forwardSpeed", speed);
    }

    private void MoveToPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        bool hasHit = Physics.Raycast(ray, out hit);

        if(hasHit)
        {
            GetComponent<NavMeshAgent>().destination = hit.point;
        }
    }
 }
