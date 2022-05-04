using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStat))]
public class CharacterCombat : MonoBehaviour
{
    public float attackSpeed = 1f;
    private float attackCooldown = 0f;

    CharacterStat myStats;

    void Start()
    {
        myStats = GetComponent<CharacterStat>();   
    }

    void Update()
    {
        attackCooldown -= Time.deltaTime;    
    }

    public void Attack (CharacterStat targetStat)
    {
        if (attackCooldown <= 0f)
        {
            targetStat.TakeDamage(myStats.damage.GetValue());
            attackCooldown = 1f / attackSpeed;
        }
    } 
}
