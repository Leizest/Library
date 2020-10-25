using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{


    int AllSlots;
    int EnabledSlots;
    GameObject[] Slots;
    public GameObject SlotFolder;
    void Start()
    {
        AllSlots = 40;
        Slots = new GameObject[AllSlots];
        for (int i = 0; i < AllSlots; i++)
        {
            Slots[i] = SlotFolder.transform.GetChild(i).gameObject;

            if (Slots[i].GetComponent<Slot>().item == null)
            {
                Slots[i].GetComponent<Slot>().Empty = true;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
            GameObject ItemPickedUp = other.gameObject;
            Item item = ItemPickedUp.GetComponent<Item>();

            AddItem(ItemPickedUp, item.ID, item.Type, item.Description, item.Icon);
        }
    }
    void AddItem(GameObject ItemObject, int ItemID, string ItemType, string ItemDescription, Sprite ItemIcon)
    {
        for (int i = 0; i < AllSlots; i++)
        {
            if (Slots[i].GetComponent<Slot>().Empty)
            {
                ItemObject.GetComponent<Item>().pickedup = true;

                Slots[i].GetComponent<Slot>().item = ItemObject;
                Slots[i].GetComponent<Slot>().icon = ItemIcon;
                Slots[i].GetComponent<Slot>().Type = ItemType;
                Slots[i].GetComponent<Slot>().ID = ItemID;
                Slots[i].GetComponent<Slot>().Description = ItemDescription;

                ItemObject.transform.parent = Slots[i].transform;
                ItemObject.SetActive(false);

                Slots[i].GetComponent<Slot>().UpdateSlots();
                Slots[i].GetComponent<Slot>().Empty = false;
            }

            return;
        }
    }
    // Update is called once per frame
    void Update()
    {


    }
}
