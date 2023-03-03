using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField]
    float MinutesTimer = 5;
    [SerializeField]
    TMP_Text TimerText,PlayerText;
    [SerializeField]
    GameObject timerUI;

    float currentTime;
    int currentPlayer = 1;

    bool gameHasBegun = false;
    bool isReady = false;
    public void BeginTimer()
    {
        timerUI.SetActive(true);
        gameHasBegun = true;
        currentTime = MinutesTimer * 60;
        ShowCurrentPlayer();
    }

    private void Update()
    {
        if (gameHasBegun)
        {
            if (isReady)
            {
                currentTime -= Time.deltaTime;
            }
            
            CalculateAndShowTimer();
            if (currentTime <= 0)
            {
                isReady = false;
                UpdatePlayerAndResetTime();
            }
        }
    }
    void UpdatePlayerAndResetTime()
    {
        currentTime = MinutesTimer * 60;
        currentPlayer = (currentPlayer % PlayerHandler.PlayersInGame) + 1;
        ShowCurrentPlayer();
    }

    void ShowCurrentPlayer()
    {
        PlayerText.text = $"Current Player {currentPlayer}";
        PlayerText.color = PlayerHandler.playerCols[currentPlayer-1];
    }

    void CalculateAndShowTimer()
    {
        int seconds = (int) currentTime % 60;
        int minutes = (int) currentTime / 60;

        string timeAsString = "";

        if (minutes < 10)
            timeAsString += "0";
        timeAsString += minutes.ToString();
        timeAsString += ":";
        if (seconds < 10)
            timeAsString += "0";
        timeAsString += seconds.ToString();

        TimerText.text = timeAsString;
    }

    public void SetReady()
    {
        isReady = true;
    }
}
