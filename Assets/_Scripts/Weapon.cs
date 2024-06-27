using System.Collections;
using System.Collections.Generic;
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
        magnum
    }

    public weapons weaponType;
    public int weaponIndex;
    public float damage;
    public int capacity;
    public int[] amountWeapon;
    public int amount;
    

    private RaycastHit hit;
    private Ray ray;

    public bool meeleAttack;

    private void Start()
    {
        weaponIndex = GameManager.instance.currentWeapon;
    }

    void Update()
    {
     weaponType = (weapons)weaponIndex;
     WeaponDamage();
     ray = new Ray(transform.position, transform.forward);
     Debug.DrawRay(ray.origin, ray.direction * 30f, Color.green);
    }

    public void Shoot()
    {
        if (amount > 0)
        {
            amount -= 1;
            if (Physics.Raycast(ray, out hit))
            { 
                Debug.Log(hit.transform.name);
                Debug.Log(damage);
            }
        }
    }

    public void MeleeAttack()
    {
        //Activar animación y dañar
        Debug.Log(damage);
        print("Ataque a meele");
    }

    
    public void WeaponDamage()
    {
        switch (weaponType)
        {
            case weapons.pistol:
                damage = 0.2f;
                meeleAttack = false;
                capacity = 15;
                amountWeapon[0] = amount; 
                break;
            case weapons.shootgun:
                damage = 0.4f;
                meeleAttack = false;
                capacity = 6;
                amountWeapon[1] = amount;
                break;
            case weapons.rifle:
                damage = 0.6f;
                meeleAttack = false;
                capacity = 10;  
                amount = amountWeapon[2];
                break;
            case weapons.magnum:
                damage = 0.8f;
                meeleAttack = false;
                capacity = 8;
                amount = amountWeapon[3];
                break;
            case weapons.knife:
                damage = 1.5f;
                meeleAttack = true;
                break;
            case weapons.axe:
                damage = 3.5f;
                meeleAttack = true;
                break;
        } 
    }
    public void ReloadInventory(int weaponId)
    {
        switch (weaponId)
        {
            case 0:
                if (GameManager.instance.pistolAmount > 0)
                {
                    var fill = capacity - amount;
                    amountWeapon[0] += fill;
                    GameManager.instance.pistolAmount -= fill;
                    amount = amountWeapon[0];
                }
                break;
            case 1:
                if (GameManager.instance.pistolAmount > 0)
                {
                    var fill = capacity - amountWeapon[1];
                    amountWeapon[1] += fill;
                    GameManager.instance.shootgunAmount -= fill;
                    amount = amountWeapon[1];
                }
                break;
            case 2:
                if (GameManager.instance.pistolAmount > 0)
                {
                    var fill = capacity - amountWeapon[2];
                    amountWeapon[2] += fill;
                    GameManager.instance.shootgunAmount -= fill;
                    amount = amountWeapon[2];
                }
                break;
            case 3:
                if (GameManager.instance.pistolAmount > 0)
                {
                    var fill = capacity - amountWeapon[3];
                    amountWeapon[3] += fill;
                    GameManager.instance.shootgunAmount -= fill;
                    amount = amountWeapon[3];
                }
                break;
        }
    }
    public void Reload()
    {
        switch (weaponType)
        {
            case weapons.pistol:
                if (GameManager.instance.pistolAmount > 0)
                {
                    var fill = capacity - amount;
                    amountWeapon[0] += fill;
                    GameManager.instance.pistolAmount -= fill;
                    amount = amountWeapon[0];
                }
                break;
            case weapons.shootgun:
                if (GameManager.instance.pistolAmount > 0)
                {
                    var fill = capacity - amountWeapon[1];
                    amountWeapon[1] += fill;
                    GameManager.instance.shootgunAmount -= fill;
                    amount = amountWeapon[1];
                }
                break;
            case weapons.rifle:
                if (GameManager.instance.pistolAmount > 0)
                {
                    var fill = capacity - amountWeapon[2];
                    amountWeapon[2] += fill;
                    GameManager.instance.shootgunAmount -= fill;
                    amount = amountWeapon[2];
                }
                break;
            case weapons.magnum:
                if (GameManager.instance.pistolAmount > 0)
                {
                    var fill = capacity - amountWeapon[3];
                    amountWeapon[3] += fill;
                    GameManager.instance.shootgunAmount -= fill;
                    amount = amountWeapon[3];
                }
                break;
        }
    }
}
