using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatActor : MonoBehaviour, IAttackable
{
    // actors current combat stats
    private CombatStats CombatStats;
    //temp stats
    public int hp;
    public int phyDef;
    public int magDef;
    public int magAttack;
    public int phyAttack;
    public float attackSpeed;
    public float attackRange;
    // temp

    private CombatStats statSheet;

    void Start()
    {
        CombatStats = new CombatStats
        {
            HealthPoints = hp,
            PhyDef = phyDef,
            MagDef = magDef,
            PhyAttack = phyAttack,
            MagAttack = magAttack,
            AttackSpeed = attackSpeed,
            AttackRange = attackRange
        };
    }


    public structCombatStats GetCombatStats()
    {
        return CombatStats.combatSheet;
    }


    public void TakeDamage(structDamage DamageRecieved)
    { 
 
        int damageTaken;
        // ignore the harvsting mods as this is a combat character
        // todo: compensate with resistances
        damageTaken = (int)Mathf.Round((DamageRecieved.MagDamageAmnt + DamageRecieved.PhyDamageAmnt) * DamageRecieved.CombatDamageMod); 
        CombatStats.HealthPoints = CombatStats.HealthPoints - damageTaken;
        Debug.Log(CombatStats.HealthPoints);
    }

    public structDamage GetDamageDealt(int amnt, structCombatStats hitTarget)
    {
        // temperyily hard coded damage
        structDamage dmgDealt = new structDamage {
            CombatDamageMod = 1,
            WoodDamageMod = 1,
            StoneDamageMod = 0,
            MagDamageAmnt = 0,
            PhyDamageAmnt = 10
        };
        return dmgDealt;
    }


}



