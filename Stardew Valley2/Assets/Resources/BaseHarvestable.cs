using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseHarvestable : MonoBehaviour, IAttackable, IHarvestable
{
    public structHarvestableStats harvestableStats;
    public int MaterialLevel
    {
        get
        {
            return harvestableStats.MaterialLevel;
        }
        set
        {
            harvestableStats.MaterialLevel = value;
        }
    }
    public int BaseHealth {
        get
        {
            return harvestableStats.BaseHealth;
        }
        set {
            harvestableStats.BaseHealth = value;
        }
    }
    public int CurrentHealth
    {
        get
        {
            return harvestableStats.CurrentHealth;
        }
        set
        {
            harvestableStats.CurrentHealth = value;
        }
    }
    public float WoodStrengthMod
    {
        get
        {
            return harvestableStats.WoodStrengthMod;
        }
        set
        {
            harvestableStats.WoodStrengthMod = value;
        }
    }
    public float StoneStrengthMod
    {
        get
        {
            return harvestableStats.StoneStrengthMod;
        }
        set
        {
            harvestableStats.StoneStrengthMod = value;
        }
    }
    public int MaterialsRemaining
    {
        get
        {
            return harvestableStats.MaterialsRemaining;
        }
        set
        {
            harvestableStats.MaterialsRemaining = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    public void TakeDamage(structDamage damage)
    {
        int woodDamage = (int)(damage.WoodDamageMod * WoodStrengthMod);
        int stoneDamage = (int)(damage.StoneDamageMod * StoneStrengthMod);
        int baseTotalDamage = (int)damage.CombatDamageMod + damage.MagDamageAmnt;
        int damageReceived =  (baseTotalDamage * woodDamage) + (baseTotalDamage * stoneDamage);
        CurrentHealth = CurrentHealth - damageReceived;
    }

    // todo: test this and player script by getting it to harvest then we will need to make
    // an implementation of this.
    public structHarvest[] Harvest(structDamage damage) {     
        if(damage.HarvestLevel > 0)
        {
            TakeDamage(damage);
            return MakeHarvestArray();
        }
        else {
            return MakeHarvestArray();
        }
    }

    structHarvest[] MakeHarvestArray() {
        structHarvest[] Harvest;
        Harvest = new structHarvest[5];
        Harvest[0] = new structHarvest { Amount = 0, Yield = structHarvest.ResourceType.EMPTY };
        return Harvest;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
