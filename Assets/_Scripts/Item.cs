using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum ItemClass
    {
        key,
        pistolAmmo,
        shootgun,
        shootgunAmmo,
        rifle,
        rifleAmmo,
        colt,
        knife,
        axe,
        coltAmmo,
        pills,
        firstAidKid,
        antidote,
        recordTape
    }
    
    public ItemClass itemType;
    public int itemAmount;
    public bool avalibleToTake;
    public bool key;
    public string keyName;
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
        if (key)
        {
            GameManager.instance.keys.Add(keyName);
        }
        else
        {
            switch (itemType)
            {
                case ItemClass.pistolAmmo:
                    GameManager.instance.pistolAmount += itemAmount;
                    break;  
                case ItemClass.shootgun:
                    GameManager.instance.shootgun = true;
                    break;
                case ItemClass.shootgunAmmo:
                    GameManager.instance.shootgunAmount+= itemAmount;
                    break;
                case ItemClass.rifle:
                    GameManager.instance.rifle = true;
                    break;
                case ItemClass.rifleAmmo:
                    GameManager.instance.rifleAmount += itemAmount;
                    break;
                case ItemClass.colt:
                    GameManager.instance.colt = true;
                    break;
                case ItemClass.coltAmmo:
                    GameManager.instance.coltAmount += itemAmount;
                    break;
                case ItemClass.knife:
                    GameManager.instance.knife = true;
                    break;
                case ItemClass.axe:
                    GameManager.instance.axe = true;
                    break;
                case ItemClass.pills:
                    GameManager.instance.pillsAmount += itemAmount;
                    break;
                case ItemClass.firstAidKid:
                    GameManager.instance.firstAidKidAmount += itemAmount;
                    break;
                case ItemClass.antidote:
                    GameManager.instance.antidoteAmount += itemAmount;
                    break;
                case ItemClass.recordTape:
                    GameManager.instance.recordTapeAmount += itemAmount;
                    break;
            }   
        }
    }
    
}
