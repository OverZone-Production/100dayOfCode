using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public Interactable focus;
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

                RemoveFocus();
            }
        }
    }

    void RemoveFocus()
    {
        if (focus != null)
            focus.OnDefocused();
        focus = null;
        mover.StopFollowTarget();
    }

    public void Interaction()
    {
        RaycastHit hit;
        bool hasHit = Physics.Raycast(GetMouseRay(), out hit);

        if (hasHit)
        {
            if (Input.GetMouseButtonDown(1))
            {
                Interactable clickedInteractable = hit.collider.GetComponent<Interactable>();
                if (clickedInteractable != null)
                {
                    SetFocus(clickedInteractable);
                }
            }
        }
    }

    void SetFocus(Interactable newFocus)
    {
        if (newFocus != focus)
        {
            if (focus != null)
                focus.OnDefocused();
            focus = newFocus;
            mover.FolllowTarget(newFocus);
        }

        newFocus.OnFocused(transform);
    }

    private static Ray GetMouseRay()
    {
        return Camera.main.ScreenPointToRay(Input.mousePosition);
    }
}
