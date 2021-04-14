using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour
{
    public GameObject item;
    public string type;
    public int ID;
    public string description; 
    public bool empty;
    public Sprite icon;
    public Transform slotIconGo;


    private void Start()   {
        slotIconGo = transform.GetChild(0);
    }

    public void UpdateSlot()    {
        slotIconGo.GetComponent<Image>().sprite = icon;
    }

   

}
