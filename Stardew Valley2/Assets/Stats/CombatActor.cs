using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatActor : MonoBehaviour, IAttackable
{
    private CbtStatSheet CombatStats;
    //temp stats
    public int hp;
    public int phyDef;
    public int magDef;
    public int magAttack;
    public int phyAttack;
    public float attackSpeed;
    public float attackRange;
    // temp

    private CharCombatStats statSheet;

    void Start()
    {
        CombatStats = new CbtStatSheet();
        CombatStats.HealthPoints = hp;
        CombatStats.PhyDef = phyDef;
        CombatStats.MagDef = magDef;
        CombatStats.PhyAttack = phyAttack;
        CombatStats.MagAttack = magAttack;
        CombatStats.AttackSpeed = attackSpeed;
        CombatStats.AttackRange = attackRange;
    }


    public CharCombatStats GetCombatStats()
    {
        return CombatStats.combatSheet;
    }


    public void TakeDamage(int amnt)
    {
        CombatStats.HealthPoints = CombatStats.HealthPoints - amnt;
        Debug.Log(CombatStats.HealthPoints);
       // statSheet.hitPoints = statSheet.hitPoints - amnt;
    }

    public int GetDamageDealt(int amnt, CharCombatStats hitTarget)
    {
        return 5;
    }

    //void IAttackable.InitCharacterSheet(int hp, int phyDef, int magDef, int magAttack, int phyAttack, float attackSpeed, float attackRange)
    //{
    //    statSheet.hitPoints = hp;
    //    statSheet.magDef = magDef;
    //    statSheet.phyDef = phyDef;
    //    statSheet.magAttack = magAttack;
    //    statSheet.phyAttack = phyAttack;
    //    statSheet.attackSpeed = attackSpeed;
    //    statSheet.attackRange = attackRange;
    //}
}



