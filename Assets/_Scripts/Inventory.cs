using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject[] inventoryViews;
    public GameObject[] inventoryWeapons;  
    public Sprite[] weaponsIMG;
    public Image weaponPreview;
    private Weapon _weapon;
    

    private void Start()
    {
        _weapon = FindObjectOfType<Weapon>();
    }

    private void OnEnable()
    {
        weaponPreview.sprite = weaponsIMG[GameManager.instance.currentWeapon];
        for (int i = 0; i < inventoryWeapons.Length; i++) 
        {
            inventoryWeapons[i].SetActive(GameManager.instance.weaponAcces[i]);
        }
    }

    public void SelectView(int view)
    {
        for (int i = 0; i < inventoryViews.Length; i++) 
        {
            if(i == view)
            {
                inventoryViews[i].SetActive(true);
            }
            else
            {
                inventoryViews[i].SetActive(false);
            }
        }
    }

    public void EquipWeapon(int index)
    {
        _weapon.weaponIndex = index;
        GameManager.instance.currentWeapon = index;
        weaponPreview.sprite = weaponsIMG[index];
    }

    public void CloseMenu()
    {
        GameManager.instance.state = GameManager.GameState.inGame;
    }
}
