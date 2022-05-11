using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : Interactable
{

    public TempStat tempStat;
    public override void Interact()
    {
        base.Interact();

        PickUp();
    }

    void PickUp()
    {
        Debug.Log("Picking up cube");
        tempStat.gainHeath(10);
        Destroy(gameObject);
    }

}
