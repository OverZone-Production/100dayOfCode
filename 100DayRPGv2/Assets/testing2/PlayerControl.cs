using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    PlayerMover mover;
    void Start()
    {
        mover = GetComponent<PlayerMover>();
    }

    // Update is called once per frame
    void Update()
    {
        MainMovement();
        Interaction();
    }

    public void MainMovement()
    {
        RaycastHit hit;
        bool hasHit = Physics.Raycast(GetMouseRay(), out hit);

        if (hasHit)
        {
            if (Input.GetMouseButtonDown(0))
            {
                mover.Move(hit.point);
            }
        }
    }

    public void Interaction()
    {
        RaycastHit hit;
        bool hasHit = Physics.Raycast(GetMouseRay(), out hit);

        if (hasHit)
        {
            if (Input.GetMouseButtonDown(1))
            {
                Debug.Log("Trying To Interact");
            }
        }
    }

    private static Ray GetMouseRay()
    {
        return Camera.main.ScreenPointToRay(Input.mousePosition);
    }
}
