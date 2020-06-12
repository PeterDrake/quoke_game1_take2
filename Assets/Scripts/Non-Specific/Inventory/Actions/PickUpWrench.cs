using UnityEngine;

[CreateAssetMenu(fileName = "New Wrench Action", menuName = "Items/Actions/Wrench")]
public class PickUpWrench : ItemAction
{
    public override bool Use(ref Item i)
    {
        Item item;
        if (Systems.Inventory.HasItem((item = Resources.Load<Item>("items/DirtyWater")),1))
        {
            Systems.Inventory.RemoveItem(item,1);
            Systems.Inventory.AddItem(Resources.Load<Item>("items/BleachWater4"), 1);
        }
        else if (Systems.Inventory.HasItem(item = Resources.Load<Item>("items/BleachWater4"), 1))
        {
            Systems.Inventory.RemoveItem(item,1);
            Systems.Inventory.AddItem(Resources.Load<Item>("items/BleachWater8"), 1);
        }
        else if (Systems.Inventory.HasItem(item = Resources.Load<Item>("items/BleachWater8"), 1))
        {
            Systems.Inventory.RemoveItem(item,1);
            Systems.Inventory.AddItem(Resources.Load<Item>("items/BleachWater12"), 1);
        }
        else if (Systems.Inventory.HasItem(item = Resources.Load<Item>("items/BleachWater12"), 1))
        {
            Systems.Inventory.RemoveItem(item,1);
            Systems.Inventory.AddItem(Resources.Load<Item>("items/BleachWater16"), 1);
        }
        else if (Systems.Inventory.HasItem(item = Resources.Load<Item>("items/BleachWater16"), 1))
        {
            Systems.Inventory.RemoveItem(item,1);
            Systems.Inventory.AddItem(Resources.Load<Item>("items/BleachWater"), 1);
        }
        return false;
    }
}
