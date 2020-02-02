using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameSession : MonoBehaviour
{

    [Header("Starting values")]
    [SerializeField] int plastic = 0;
    [SerializeField] int playerLives = 5;

    // [Header("Index number in File/Build Settings; if excluded, will use next in order")]
    int? nextScene;

    private int maxPlastic = 10;

    private LightLevel lightLevel;

    void Awake()
    {

    }

    private void Start()
    {
        lightLevel = FindObjectOfType<LightLevel>();
        maxPlastic = 0;
        foreach (Collectable p in FindObjectsOfType<Collectable>())
        {
            maxPlastic += p.score;
        }
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
        lightLevel.DimLights(num / (float)maxPlastic);
        if (plastic >= maxPlastic)
        {
            if (nextScene == null)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            {
                SceneManager.LoadScene((int)nextScene);
            }
        }
    }

    public void takePlastic(int num)
    {
        plastic -= num;
    }

    public int getPlastic()
    {
        return plastic;
    }
    public int getPlasticRemaining()
    {
        return maxPlastic - plastic;
    }
}