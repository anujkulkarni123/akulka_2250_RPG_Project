using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public string type;
    public int ID;
    public string description;
    public Sprite icon;

    public bool pickedUp;

    [HideInInspector]
    public bool equipped;
    
    [HideInInspector]
    public GameObject profile;

    [HideInInspector]
    public GameObject profileManager;
    public bool playersProfile;

public void Start() {
    profileManager = GameObject.FindWithTag("ProfileManager");

    if (!playersProfile) {
        int allProfiles = profileManager.transform.childCount;
        for (int i = 0; i < allProfiles; i++)    {
            if (profileManager.transform.GetChild(i).gameObject.GetComponent<Item>().ID == ID) {
                profile = profileManager.transform.GetChild(i).gameObject;
                print(profile.name);
            }
        }
    }
}

    public void Update()    {
       if(equipped) {
           //perform acts here

           if(Input.GetKeyDown(KeyCode.G))  {
               this.gameObject.SetActive(false);
           }
       } 
    }

    public void ItemUsage() {
        //jersey
        if (type == "Jersey1")   {
            profile.SetActive(true);
            equipped = true;

        }
        //shoe
        if (type == "Shoe1")  {
            profile.SetActive(true);
            equipped = true;
        }
    }
       
}
