using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{

    public string Name = "item";
    public int ItemId = 0;
    public enum InventoryActions{USE, EXAMINE}
    public string Examine() {
        string examineMessage = "This {0} is the first", Name;
        return examineMessage;
            }
}
