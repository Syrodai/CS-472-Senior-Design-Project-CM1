using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colony : MonoBehaviour
{
    public List<Zone> zones = new List<Zone>();
    [SerializeField] private SpriteRenderer zoneSprite;
    [SerializeField] private string colonyName = "Test Colony";

    public string GetColonyName()
    {
        return colonyName;
    }

    /////////////////////////////////////
    // Global Storage Methods
    /////////////////////////////////////

    public bool ColonyHasItem(string itemName, int quantity)
    {
        return (GlobalStorage_VM.GetItemCount(itemName) > quantity);
    }

    public int GetNumberOfItemInGalaxy(string itemName)
    {
        return GlobalStorage_VM.GetItemCount(itemName);
    }

    /*public bool RemoveItemFromColony(Item item, int quantity)
    {
        if(GlobalStorage_VM.GetItemCount(item.itemName) < quantity)
        {
            return false;
        }

        List<Chest_VM> chestWithItem = GlobalStorage_VM.GetChestWithItem(item);
        foreach(Chest_VM chest in chestWithItem)
        {
            if(quantity <= 0)
            {
                break;
            }

            int itemsDeleted = chest.ItemCountInChest(item.itemName);
            if(itemsDeleted < quantity)
            {
                chest.RemoveItemFromChest(item.itemName, itemsDeleted);
                quantity -= itemsDeleted;
            }
            else
            {
                chest.RemoveItemFromChest(item.itemName, quantity);
                quantity = 0;
            }
        }

        return true;
    }*/

    /*public void AddItemToColony(Item item)
    {
        Chest_VM lootLocation = GlobalStorage_VM.GetClosestChest(new Vector3());
        if(lootLocation == null)
        {
            return;
        }

        lootLocation.AddItem(item);
    }*/

    /////////////////////////////////////
    // Zone Methods 
    /////////////////////////////////////

    public void AddZone(Zone newZone)
    {
        zones.Add(newZone);
    }

    public int GetNextZoneNumber()
    {
        return zones.Count+1;
    }

    public Sprite GetZoneSprite()
    {
        return zoneSprite.sprite;
    }

    public void RemoveZone(Zone zoneToRemove)
    {
        Destroy(zoneToRemove.GetVisualBox());
        if(zones.Contains(zoneToRemove))
        {
            zones.Remove(zoneToRemove);
        }
    }

    public List<Zone> GetZones()
    {
        return zones;
    }
}