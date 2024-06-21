using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public enum  inventory
    {
        weapons,
        items,
        map,
        archive
    }
    public inventory inventoryView;

    public GameObject[] inventoryViews;
    
    void Update()
    {
        switch (inventoryView)
        {
            case inventory.weapons:
                inventoryViews[0].SetActive(true);
                inventoryViews[1].SetActive(false);
                inventoryViews[2].SetActive(false);
                inventoryViews[3].SetActive(false);
                break;
            case inventory.items:
                inventoryViews[1].SetActive(true);
                inventoryViews[0].SetActive(false);
                inventoryViews[2].SetActive(false);
                inventoryViews[3].SetActive(false);
                break;
            case inventory.map:
                inventoryViews[2].SetActive(true);
                inventoryViews[1].SetActive(false);
                inventoryViews[0].SetActive(false);
                inventoryViews[3].SetActive(false);
                break;
            case inventory.archive:
                inventoryViews[3].SetActive(true);
                inventoryViews[1].SetActive(false);
                inventoryViews[2].SetActive(false);
                inventoryViews[0].SetActive(false);
                break;
        }
    }

    public void SelectView(inventory view)
    {
        inventoryView = view;
    }
}
