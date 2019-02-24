using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttackable 
{

   // void InitCharacterSheet(int hp, int phyDef, int magDef, int magAttack, int phyAttack, float attackSpeed, float attackRange);
    void TakeDamage(structDamage damage);

}
