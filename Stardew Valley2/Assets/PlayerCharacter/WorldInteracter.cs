using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldInteracter : MonoBehaviour
{
    public RaycastHit2D RayHit;
    public LayerMask hittableLayer;


    IHittable CheckForHitable(Vector2 direction) {
        IHittable hitObject = null;

        RayHit = Physics2D.BoxCast(transform.position, new Vector2(0.3f, 0.3f), 0, direction, 0.1f, hittableLayer);
        if (RayHit) hitObject = RayHit.collider.gameObject.GetComponent<IHittable>();
        return hitObject;
    }

    public void TryHit(Vector2 direction) {
        IHittable Hitable = CheckForHitable(direction);
        
        if(Hitable != null) {

            structDamage damage = new structDamage
            {
                HarvestLevel = 50,
                PhyDamageAmnt = 10,
                StoneDamageMod = 1,
                WoodDamageMod = 1,
            };

            structHarvest[]  harvest = Hitable.TakeHit(damage);

            Debug.Log(harvest[0].Amount);
            Debug.Log(harvest[0].Yield);
        }
    }


}
