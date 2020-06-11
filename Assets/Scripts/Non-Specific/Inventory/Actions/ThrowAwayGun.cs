using UnityEngine;

[CreateAssetMenu(fileName = "New Throw Away Gun Action", menuName = "Items/Actions/Gun")]
public class ThrowAwayGun : ItemAction
{
    public override bool Use(ref Item i)
    {
        
        if (Systems.Inventory.HasItem((i = Resources.Load<Item>("items/Gun")),1))
        {
            Systems.Inventory.RemoveItem(i,1);
        }
        
        return false;
    }
}
