﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    [SerializeField] int plastic = 0;
    [SerializeField] int playerLives = 5;

    void Awake()
    {
        
    }

    private void Start()
    {
        
    }

    public int getPlayerLives()
    {
        return playerLives;
    }

    public void setPlayerLives(int playerLives)
    {
        this.playerLives = playerLives;
    }

    public void addPlastic(int num)
    {
        plastic += num;
        Debug.Log(plastic);
    }

    public void takePlastic(int num)
    {
        plastic -= num;
    }
}
