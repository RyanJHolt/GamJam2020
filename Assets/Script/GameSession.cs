using System.Collections;
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

    public void addLives(int num)
    {
        playerLives += num;
    }

    public void takeLives(int num)
    {
        playerLives -= num;
        Debug.Log(playerLives);
    }

    public int getPlayerLives()
    {
        return playerLives;
    }

    public void addPlastic(int num)
    {
        plastic += num;
    }

    public void takePlastic(int num)
    {
        plastic -= num;
    }
    
    public int getPlastic()
    {
        return plastic;
    }
}
