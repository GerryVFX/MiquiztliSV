using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Rendering;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Image currentWeapon;
    [SerializeField] private Sprite[] weaponPreview;
    
    [SerializeField] private GameObject pistol;
    [SerializeField] private GameObject shootgun;
    [SerializeField] private GameObject rifle;
    [SerializeField] private GameObject colt;
    [SerializeField] private GameObject knife;
    [SerializeField] private GameObject axe;
    [SerializeField] private GameObject[] equipLabel;
    
    [SerializeField] private TMP_Text pistolCharge;
    [SerializeField] private TMP_Text shootgunCharge;
    [SerializeField] private TMP_Text rifleCharge;
    [SerializeField] private TMP_Text coltCharge;

    private Weapon weapon;
    public string type;
    public int capacity;
    public int recharge;
    public int itemIndex;
    private void OnEnable()
    {
        weapon = FindObjectOfType<Weapon>();
        
        pistol.SetActive(GameManager.instance.pistol);
        shootgun.SetActive(GameManager.instance.shootgun);
        rifle.SetActive(GameManager.instance.rifle);
        colt.SetActive(GameManager.instance.colt);
        knife.SetActive(GameManager.instance.knife);
        axe.SetActive(GameManager.instance.axe);
        
        for (int i = 0; i < equipLabel.Length; i++)
        {
            if (i == GameManager.instance.indexWeapon) equipLabel[i].SetActive(true);
            else equipLabel[i].SetActive(false);
        }

        currentWeapon.sprite = weaponPreview[GameManager.instance.indexWeapon];
        
        pistolCharge.text = string.Format("x: {0}", GameManager.instance.pistolCharge);
        shootgunCharge.text = string.Format("x: {0}", GameManager.instance.shootgunCharge);
        rifleCharge.text = string.Format("x: {0}", GameManager.instance.rifleCharge);
        coltCharge.text = string.Format("x: {0}", GameManager.instance.coltCharge);
    }

    public void PreviewWeapon(int current)
    {
        currentWeapon.sprite = weaponPreview[current];
        switch (current)
        {
            case 0:
                type = "pistol";
                break;
            case 1:
                type = "shootgun";
                break;
            case 2:
                type = "rifle";
                break;
            case 3:
                type = "colt";
                break;
            case 4:
                type = "knife";
                break;
            case 5:
                type = "axe";
                break;
        }
    }

    public void Equip()
    {
        switch (type)
        {
            case "pistol":
                weapon.weaponType = Weapon.weapons.pistol;
                itemIndex = 0;
                for (int i = 0; i < equipLabel.Length; i++)
                {
                    if (i == itemIndex) equipLabel[i].SetActive(true);
                    else equipLabel[i].SetActive(false);
                }
                break;
            case "shootgun":
                weapon.weaponType = Weapon.weapons.shootgun;
                itemIndex = 1;
                for (int i = 0; i < equipLabel.Length; i++)
                {
                    if (i == itemIndex) equipLabel[i].SetActive(true);
                    else equipLabel[i].SetActive(false);
                }
                break;
            case "rifle":
                weapon.weaponType = Weapon.weapons.rifle;
                itemIndex = 2;
                for (int i = 0; i < equipLabel.Length; i++)
                {
                    if (i == itemIndex) equipLabel[i].SetActive(true);
                    else equipLabel[i].SetActive(false);
                }
                break;
            case "colt":
                weapon.weaponType = Weapon.weapons.colt;
                itemIndex = 3;
                for (int i = 0; i < equipLabel.Length; i++)
                {
                    if (i == itemIndex) equipLabel[i].SetActive(true);
                    else equipLabel[i].SetActive(false);
                }
                break;
            case "knife":
                weapon.weaponType = Weapon.weapons.knife;
                itemIndex = 4;
                for (int i = 0; i < equipLabel.Length; i++)
                {
                    if (i == itemIndex) equipLabel[i].SetActive(true);
                    else equipLabel[i].SetActive(false);
                }
                break;
            case "axe":
                weapon.weaponType = Weapon.weapons.axe;
                itemIndex = 5;
                for (int i = 0; i < equipLabel.Length; i++)
                {
                    if (i == itemIndex) equipLabel[i].SetActive(true);
                    else equipLabel[i].SetActive(false);
                }
                break;
        }
    }

    public void Reload()
    {
        switch (type)
        {
            case "pistol":
                capacity = 15;
                recharge = capacity - GameManager.instance.pistolCharge;
                for (int i = 0; i < recharge; i++)
                {
                    if (GameManager.instance.pistolAmount > 0)
                    {
                        GameManager.instance.pistolAmount -= 1;
                        GameManager.instance.pistolCharge += 1;
                        pistolCharge.text = string.Format("x: {0}", GameManager.instance.pistolCharge);
                    }
                    else return;
                }
                break;
            case "shootgun":
                capacity = 7;
                recharge = capacity - GameManager.instance.shootgunCharge;
                for (int i = 0; i < recharge; i++)
                {
                    if (GameManager.instance.shootgunAmount > 0)
                    {
                        GameManager.instance.shootgunAmount -= 1;
                        GameManager.instance.shootgunCharge += 1;
                        shootgunCharge.text = string.Format("x: {0}", GameManager.instance.shootgunCharge);
                    }
                    else return;
                }
                break;
            case "rifle":
                capacity = 10;
                recharge = capacity - GameManager.instance.rifleCharge;
                for (int i = 0; i < recharge; i++)
                {
                    if (GameManager.instance.rifleAmount > 0)
                    {
                        GameManager.instance.rifleAmount -= 1;
                        GameManager.instance.rifleCharge += 1;
                        rifleCharge.text = string.Format("x: {0}", GameManager.instance.rifleCharge);
                    }
                    else return;
                }
                break;
            case "colt":
                capacity = 8;
                recharge = capacity - GameManager.instance.coltCharge;
                for (int i = 0; i < recharge; i++)
                {
                    if (GameManager.instance.coltAmount > 0)
                    {
                        GameManager.instance.coltAmount -= 1;
                        GameManager.instance.coltCharge += 1;
                        coltCharge.text = string.Format("x: {0}", GameManager.instance.coltCharge);
                    }
                    else return;
                }
                break;
        }
    }

    public void Close()
    {
        GameManager.instance.indexWeapon = itemIndex;
        GameManager.instance.OpenInventory();
    }
}
