using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public enum weapons
    {
        none,
        pistol,
        shootgun,
        rifle,
        magnum,
        knife,
        axe
    }

    public weapons weaponType;
    public float damage;

    private RaycastHit hit;
    private Ray ray;

    public bool meeleAttack;
    void Update()
    {
     WeaponDamage();
     ray = new Ray(transform.position, transform.forward);
     Debug.DrawRay(ray.origin, ray.direction * 30f, Color.green);
    }

    public void Shoot()
    {
        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log(hit.transform.name);
            Debug.Log(damage);
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
            case weapons.none:
                damage = 0f;
                meeleAttack = false;
                break;
            case weapons.pistol:
                damage = 0.2f;
                meeleAttack = false;
                break;
            case weapons.shootgun:
                damage = 0.4f;
                meeleAttack = false;
                break;
            case weapons.rifle:
                damage = 0.6f;
                meeleAttack = false;
                break;
            case weapons.magnum:
                damage = 0.8f;
                meeleAttack = false;
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
}
