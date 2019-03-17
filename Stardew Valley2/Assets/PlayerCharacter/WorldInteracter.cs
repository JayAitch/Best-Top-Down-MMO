using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldInteracter : MonoBehaviour
{
    public RaycastHit2D RayHit;
    public LayerMask hittableLayer;
    public Item[] Items;

    private float time = 0.0f;
    // assigned in editor for now
    public float actionSpeed;
    private void Start()
    {
        Items = new Item[28];
    }
    bool UpdateHitTime()
    {
        time += Time.deltaTime;
        if (time >= actionSpeed)
        {
            time = time - actionSpeed;
            return true;
        }
        return false;
    }

    IHittable CheckForHitable(Vector2 direction) {
        IHittable hitObject = null;

        RayHit = Physics2D.BoxCast(transform.position, new Vector2(0.3f, 0.3f), 0, direction, 0.1f, hittableLayer);
        if (RayHit) hitObject = RayHit.collider.gameObject.GetComponent<IHittable>();
        return hitObject;
    }

    public void TryHit(Vector2 direction) {

        if (UpdateHitTime())
        {
            IHittable Hitable = CheckForHitable(direction);

            if (Hitable != null)
            {

                structDamage damage = new structDamage
                {
                    HarvestLevel = 50,
                    PhyDamageAmnt = 10,
                    StoneDamageMod = 1,
                    WoodDamageMod = 1,
                };

                structHarvest[] harvest = Hitable.TakeHit(damage);
                Debug.Log("harvet start");
                Debug.Log(harvest[0].Amount);
                //Debug.Log(harvest[0].Yield.Name);
                AddToInventory(harvest[0].Yield, 1); // not like this
            }
        }
    }

    private void AddToInventory(Item item, int quantity) {
        int currentSlot = 0;
       foreach (Item currentItem in Items) {

            if (currentItem == null)
            {
                Items[currentSlot] = item;
                testInvent();
                return;
            }
            currentSlot++;
        }

    }


    private void testInvent() {
        int slot = 0;
        foreach (Item currentItem in Items)
        {
            slot++;
            string invetoryPrint = "print";
            if (currentItem == null)
            {

                invetoryPrint = "Invent Print slot: " + slot + "empty";
            }
            else
            {
                invetoryPrint = "Invent Print slot: " + slot + "Name: " + currentItem.Name;
            }

            Debug.Log(invetoryPrint);
        }
    }


}
