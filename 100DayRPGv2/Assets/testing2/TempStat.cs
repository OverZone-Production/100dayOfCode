using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempStat : MonoBehaviour
{
    public int health;
    public int damage;

    public void gainHeath(int amount)
    {
        health += amount;
    }

    public void gainDamage(int amount)
    {
        damage += amount;

    }
}
