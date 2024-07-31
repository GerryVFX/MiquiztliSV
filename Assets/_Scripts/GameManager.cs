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

    public int indexWeapon;
    
    //Items de consumo
    public int pistolAmount;
    public int pistolCharge;
    public int shootgunAmount;
    public int shootgunCharge;
    public int rifleAmount;
    public int rifleCharge;
    public int coltAmount;
    public int coltCharge;
    public int pillsAmount;
    public int firstAidKidAmount;
    public int antidoteAmount;
    public int recordTapeAmount;

    public List<string> keys = new List<string>();
    public GameObject inventoryPref;
    private GameObject inventory;
    public GameObject pausePref;
    private GameObject pause;
    
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

    public void Pause()
    {
        if (state == GameState.inGame)
        {
            state = GameState.inPause;
            if (pause == null)
            {
                pause = Instantiate(pausePref);
                pause.SetActive(true);
            }
            else
            {
                pause.SetActive(true);
            }
            
            Time.timeScale = 0;
        }
        else if(state == GameState.inPause)
        {
            state = GameState.inGame;
            pause.SetActive(false);
            Time.timeScale = 1;
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
