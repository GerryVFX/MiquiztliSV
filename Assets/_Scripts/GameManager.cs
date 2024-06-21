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
    public bool[] weaponAcces;
    public int currentWeapon;

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
