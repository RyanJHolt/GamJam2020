using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    private GameSession session;
    [SerializeField] TMPro.TMP_Text livesCounter, plasticCounter;

    void Start()
    {
        session = FindObjectOfType<GameSession>();
    }

    void Update()
    {
        livesCounter.text = "Lives: " + session.getPlayerLives();
    }
}