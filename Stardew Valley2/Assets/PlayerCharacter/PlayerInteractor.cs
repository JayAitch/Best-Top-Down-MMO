using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    public CombatActor combatActor;
    // Start is called before the first frame update
    void Start()
    {
      // combatActor = this.GetComponent<CombatActor>();
    }

    // Update is called once per frame
    void Update()
    {

            combatActor.TakeDamage(1);


    }
}
