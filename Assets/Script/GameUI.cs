using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    private GameSession session;
    [SerializeField] UnityEngine.UI.Text livesCounter, plasticCounter;

    void Start()
    {
        session = FindObjectOfType<GameSession>();
    }

    void Update()
    {
        livesCounter.text = "" + session.getPlayerLives();
    }
}