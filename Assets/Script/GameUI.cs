using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    private GameSession session;
    [SerializeField] TMPro.TMP_Text livesCounter, wasteCounter;

    void Start()
    {
        session = FindObjectOfType<GameSession>();
    }

    void Update()
    {
        wasteCounter.text = "<b>Waste:</b> " + session.getPlastic();
        livesCounter.text = "<b>Lives:</b> " + session.getPlayerLives();
    }
}