using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Rendering;

public class Inventory : MonoBehaviour
{
    public GameObject content;
    public GameObject[] inventoryViews;
    public GameObject[] inventoryWeapons;  
    public Sprite[] weaponsIMG;
    public Image weaponPreview;
    private Weapon _weapon;
    public GameObject[] itemsView;
    public TMP_Text[] itemsAmount;
    
    private void Start()
    {
        _weapon = FindObjectOfType<Weapon>();
    }
    private void Update()
    {
        CheckItems();
        
        weaponPreview.sprite = weaponsIMG[GameManager.instance.currentWeapon];
        for (int i = 0; i < inventoryWeapons.Length; i++) 
        {
            inventoryWeapons[i].SetActive(GameManager.instance.weaponAcces[i]);
        }
        
        if (GameManager.instance.state == GameManager.GameState.onMenu)
        {
            content.SetActive(true);
        }
        else if(GameManager.instance.state == GameManager.GameState.inGame)
        {
            content.SetActive(false);
        }
    }

    public void CheckItems()
    {
        if(GameManager.instance.pistolAmount>0)itemsView[0].SetActive(true);
        else itemsView[0].SetActive(false);
        itemsAmount[0].text = string.Format("x: {0}", GameManager.instance.pistolAmount);
        if(GameManager.instance.shootgunAmount>0)itemsView[1].SetActive(true);
        else itemsView[1].SetActive(false);
        itemsAmount[1].text = string.Format("x: {0}", GameManager.instance.shootgunAmount);
        if(GameManager.instance.rifleAmount>0)itemsView[2].SetActive(true);
        else itemsView[2].SetActive(false);
        itemsAmount[2].text = string.Format("x: {0}", GameManager.instance.rifleAmount);
        if(GameManager.instance.coltAmount>0)itemsView[3].SetActive(true);
        else itemsView[3].SetActive(false);
        itemsAmount[3].text = string.Format("x: {0}", GameManager.instance.coltAmount);
        if(GameManager.instance.pills>0)itemsView[4].SetActive(true);
        else itemsView[4].SetActive(false);
        itemsAmount[4].text = string.Format("x: {0}", GameManager.instance.pills);
        if(GameManager.instance.firstAidKid>0)itemsView[5].SetActive(true);
        else itemsView[5].SetActive(false);
        itemsAmount[5].text = string.Format("x: {0}", GameManager.instance.firstAidKid);
        if(GameManager.instance.antidote>0)itemsView[6].SetActive(true);
        else itemsView[6].SetActive(false);
        itemsAmount[6].text = string.Format("x: {0}", GameManager.instance.antidote);
        if(GameManager.instance.recordTape>0)itemsView[7].SetActive(true);
        else itemsView[7].SetActive(false);
        itemsAmount[7].text = string.Format("x: {0}", GameManager.instance.recordTape);
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
