using UnityEngine;

[CreateAssetMenu(fileName = "New Bleach Action", menuName = "Items/Actions/Tablet")]
public class AddTablet : ItemAction
{
    public override bool Use(ref Item i)
    {
        Item item;
        if (Systems.Inventory.HasItem((item = Resources.Load<Item>("Items/DirtyMustardWater")), 1))
        {
            Systems.Inventory.RemoveItem(item, 1);
            Systems.Inventory.AddItem(Resources.Load<Item>("Items/CleanMustardWater"), 1);
        }
        return false;
    }
}
