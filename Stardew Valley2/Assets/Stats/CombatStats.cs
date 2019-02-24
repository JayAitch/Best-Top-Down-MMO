using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatStats : MonoBehaviour
{
    public int HealthPoints
    {
        get
        {
            return combatSheet.healthPoints;
        }
        set
        {
            combatSheet.healthPoints = value;
        }
    }

    public int PhyDef
    {
        get
        {
            return combatSheet.phyDef;
        }
        set
        {
            combatSheet.phyDef = value;
        }
    }
    public int MagDef
    {
        get
        {
            return combatSheet.magDef;
        }
        set
        {
            combatSheet.magDef = value;
        }
    }
    public int PhyAttack
    {
        get
        {
            return combatSheet.phyAttack;
        }
        set
        {
            combatSheet.phyAttack = value;
        }
    }

    public int MagAttack
    {
        get
        {
            return combatSheet.magAttack;
        }
        set
        {
            combatSheet.magAttack = value;
        }
    }

    public float AttackSpeed
    {
        get
        {
            return combatSheet.attackSpeed;
        }
        set
        {
            combatSheet.attackSpeed = value;
        }
    }
    public float AttackRange
    {
        get
        {
            return combatSheet.attackRange;
        }
        set
        {
            combatSheet.attackRange = value;
        }
    }


    public structCombatStats combatSheet;
    public CombatStats() {
        combatSheet = new structCombatStats();
    }




}



