using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{

    public GameObject inventory;
    private bool inventoryEnabled;

    public static Inventory instance;
    
    private int allSlots;

    private GameObject[] slot;

    public GameObject slotHolder;


    private void Awake()    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else    {
            Destroy(this.gameObject);
        }
    }
    void Start()
    {
        allSlots=4;
        slot = new GameObject[allSlots];

        for (int i = 0; i < allSlots; i++)
        {
            slot[i] = slotHolder.transform.GetChild(i).gameObject;
            if (slot[i].GetComponent<Slot>().item == null)
            {
                slot[i].GetComponent<Slot>().empty = true;
            }
        }
    }

    private void Update()   {
        if (Input.GetKeyDown(KeyCode.I))    {
            inventoryEnabled = !inventoryEnabled;
        }
            
        if (inventoryEnabled == true)   {
            inventory.gameObject.SetActive(true);
        } else {
            inventory.gameObject.SetActive(false);
        }

    }


    public void AddItem(GameObject itemObject, int itemID, string itemType, string itemDescription, Sprite itemIcon)
    {
        for (int i = 0; i < allSlots; i++)
        {
            if (slot[i].GetComponent<Slot>().empty)
            {
                // add item to slot
                itemObject.GetComponent<Item>().pickedUp = true;

                
                slot[i].GetComponent<Slot>().item = itemObject;
                slot[i].GetComponent<Slot>().icon = itemIcon;
                slot[i].GetComponent<Slot>().type = itemType;
                slot[i].GetComponent<Slot>().ID = itemID;
                slot[i].GetComponent<Slot>().description = itemDescription;

                itemObject.transform.parent = slot[i].transform;
                itemObject.SetActive(false);


                slot[i].GetComponent<Slot>().UpdateSlot();
                slot[i].GetComponent<Slot>().empty = false;

                if (itemID == 1)
                {
                    playerVariables.PV.Jersey1 = true;
                }
                if (itemID == 2)
                {
                    Control.playerSpeed = 8;
                }
                if (itemID == 3) 
                {
                    playerVariables.PV.Jersey2 = true;
                }
                if (itemID == 4)    
                {
                    Control.gravityValue = -9.5f;
                }
                return;
            }
            
        }
    }

}
