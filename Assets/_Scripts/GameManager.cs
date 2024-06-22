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
    public bool[] weaponAcces;
    public int currentWeapon;
    
    //Items de consumo
    public int pistolAmount;
    public int shootgunAmount;
    public int rifleAmount;
    public int coltAmount;
    public int pills;
    public int firstAidKid;
    public int antidote;
    public int recordTape;
    
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

    private void Update()
    {
        if(state == GameState.inGame)
        {
            Time.timeScale = 1;
            if(Input.GetKeyDown(KeyCode.Space))
            {
                state = GameState.onMenu;
                Time.timeScale = 0;
            }
        }
    }
}
