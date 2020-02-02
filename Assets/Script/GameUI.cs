using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    private GameSession session;
    private playerController player;
    [SerializeField] TMPro.TMP_Text livesCounter, wasteCounter;
    [SerializeField] UnityEngine.UI.Image dashWidget;

    void Start()
    {
        player = FindObjectOfType<playerController>();
        session = FindObjectOfType<GameSession>();
    }

    void Update()
    {
        wasteCounter.text = "<b>Waste:</b> " + session.getPlasticRemaining();
        livesCounter.text = "<b>Lives:</b> " + session.getPlayerLives();
        if (player.dashing)
        {
            dashWidget.color = Color.grey;
        }
        else
        {
            dashWidget.color = player.canDash ? Color.green : Color.red;
        }
    }
}