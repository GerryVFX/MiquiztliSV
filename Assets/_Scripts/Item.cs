using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum ItemClass
    {
        pistol,
        shootgun,
        rifle,
        colt,
        pills,
        firstAidKid,
        antidote,
        recordTape
    }

    private Inventory _inventory;
    public ItemClass itemType;
    public int itemAmount;
    public bool avalibleToTake;

    private void Start()
    {
        _inventory = FindObjectOfType<Inventory>();
    }

    private void Update()
    {
        if (avalibleToTake)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                TakeItem();
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            avalibleToTake = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            avalibleToTake = false;
        }
    }

    public void TakeItem()
    {
        switch (itemType)
        {
            case ItemClass.pistol:
                GameManager.instance.pistolAmount += itemAmount;
                break;
            case ItemClass.shootgun:
                GameManager.instance.shootgunAmount+= itemAmount;
                break;
            case ItemClass.rifle:
                GameManager.instance.rifleAmount += itemAmount;
                break;
            case ItemClass.colt:
                GameManager.instance.coltAmount += itemAmount;
                break;
            case ItemClass.pills:
                GameManager.instance.pills += itemAmount;
                break;
            case ItemClass.firstAidKid:
                GameManager.instance.firstAidKid += itemAmount;
                break;
            case ItemClass.antidote:
                GameManager.instance.antidote+= itemAmount;
                break;
            case ItemClass.recordTape:
                GameManager.instance.recordTape += itemAmount;
                break;
        }
    }
}
