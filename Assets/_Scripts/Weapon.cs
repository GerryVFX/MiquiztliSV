using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public enum weapons
    {
        pistol,
        shootgun,
        rifle,
        knife,
        axe,
        colt
    }

    public weapons weaponType;

    private int capacity;
    private int recharge;
    private RaycastHit hit;
    private Ray ray;

    private void Start()
    {
        ray = new Ray(transform.position, transform.forward);
        switch (GameManager.instance.indexWeapon)
        {
            case 0:
                weaponType = weapons.pistol;
                break;
            case 1:
                weaponType = weapons.shootgun;
                break;
            case 2:
                weaponType = weapons.rifle;
                break;
            case 3:
                weaponType = weapons.colt;
                break;
            case 4:
                weaponType = weapons.knife;
                break;
            case 5:
                weaponType = weapons.axe;
                break;
        }
    }

    public void UseWeapon()
    {
        switch (weaponType)
        {
            case weapons.pistol:
                if (GameManager.instance.pistolCharge > 0)
                {
                    if (Physics.Raycast(transform.position, Vector3.forward, out hit))
                    {
                        print(hit.transform.gameObject.name);
                        GameManager.instance.pistolCharge -= 1;
                    }   
                }
                break;
            case weapons.shootgun:
                if (GameManager.instance.shootgunCharge > 0)
                {
                    if (Physics.Raycast(transform.position, Vector3.forward, out hit))
                    {
                        print(hit.transform.gameObject.name);
                        GameManager.instance.shootgunCharge -= 1;
                    }   
                }
                break;
            case weapons.rifle:
                if (GameManager.instance.rifleCharge > 0)
                {
                    if (Physics.Raycast(transform.position, Vector3.forward, out hit))
                    {
                        print(hit.transform.gameObject.name);
                        GameManager.instance.rifleCharge -= 1;
                    }   
                }
                break;
            case weapons.colt:
                if (GameManager.instance.coltCharge > 0)
                {
                    if (Physics.Raycast(transform.position, Vector3.forward, out hit))
                    {
                        print(hit.transform.gameObject.name);
                        GameManager.instance.coltCharge -= 1;
                    }   
                }
                break;
            case weapons.knife:
                break;
            case weapons.axe:
                break;
        }
    }

    public void Reload()
    {
        switch (weaponType)
        {
            case weapons.pistol:
                capacity = 15;
                recharge = capacity - GameManager.instance.pistolCharge;
                for (int i = 0; i < recharge; i++)
                {
                    if (GameManager.instance.pistolAmount > 0)
                    {
                        GameManager.instance.pistolAmount -= 1;
                        GameManager.instance.pistolCharge += 1;
                    }
                    else return;
                }
                break;
            case weapons.shootgun:
                capacity = 7;
                recharge = capacity - GameManager.instance.shootgunCharge;
                for (int i = 0; i < recharge; i++)
                {
                    if (GameManager.instance.shootgunAmount > 0)
                    {
                        GameManager.instance.shootgunAmount -= 1;
                        GameManager.instance.shootgunCharge += 1;
                    }
                    else return;
                }
                break;
            case weapons.rifle:
                capacity = 10;
                recharge = capacity - GameManager.instance.rifleCharge;
                for (int i = 0; i < recharge; i++)
                {
                    if (GameManager.instance.rifleAmount > 0)
                    {
                        GameManager.instance.rifleAmount -= 1;
                        GameManager.instance.rifleCharge += 1;
                    }
                    else return;
                }
                break;
            case weapons.colt:
                capacity = 8;
                recharge = capacity - GameManager.instance.coltCharge;
                for (int i = 0; i < recharge; i++)
                {
                    if (GameManager.instance.coltAmount > 0)
                    {
                        GameManager.instance.coltAmount -= 1;
                        GameManager.instance.coltCharge += 1;
                    }
                    else return;
                }
                break;
        }
    }
}
