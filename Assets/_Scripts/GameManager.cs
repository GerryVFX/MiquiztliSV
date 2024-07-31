using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public float playerLife = 1;

    public enum GameState
    {
        inGame,
        inPause,
        onMenu,
        cinematic
    }
    public GameState state;
    
    //Control de armas
    public bool pistol;
    public bool shootgun;
    public bool rifle;
    public bool colt;
    public bool knife;
    public bool axe;
    
    //Items de consumo
    public int pistolAmount;
    public int shootgunAmount;
    public int rifleAmount;
    public int coltAmount;
    public bool pills;
    public int pillsAmount;
    public bool firstAidkid;
    public int firstAidKidAmount;
    public bool antidote;
    public int antidoteAmount;
    public bool recordTape;
    public int recordTapeAmount;

    public List<string> keys = new List<string>();
    public GameObject inventoryPref;
    public GameObject inventory;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }
    public void OpenInventory()
    {
        if (state == GameState.inGame)
        {
            state = GameState.onMenu;
            if (inventory == null)
            {
               inventory = Instantiate(inventoryPref);
               inventory.SetActive(true);
            }
            else
            {
                inventory.SetActive(true);
            }
            
            Time.timeScale = 0;
        }
        else if(state == GameState.onMenu)
        {
            state = GameState.inGame;
            inventory.SetActive(false);
            Time.timeScale = 1;
        }
        
    }
}
