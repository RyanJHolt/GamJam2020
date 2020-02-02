using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour {
    //TODO: In Start(), get number of plastic pieces in level, assign to maxPlastic
    [SerializeField] int plastic = 0;
    private int maxPlastic = 10;
    [SerializeField] int playerLives = 5;

    private LightLevel lightLevel;

    void Awake() {

    }

    private void Start() {
        lightLevel = FindObjectOfType<LightLevel>();
        maxPlastic = 0;
        foreach (plastic p in FindObjectsOfType<plastic>()) {
            maxPlastic += p.score;
        }
    }

    public void addLives(int num) {
        playerLives += num;
    }

    public void takeLives(int num) {
        playerLives -= num;
        Debug.Log(playerLives);
    }

    public int getPlayerLives() {
        return playerLives;
    }

    public void addPlastic(int num) {
        plastic += num;
        lightLevel.DimLights(num / (float) maxPlastic);
    }

    public void takePlastic(int num) {
        plastic -= num;
    }

    public int getPlastic() {
        return plastic;
    }
}