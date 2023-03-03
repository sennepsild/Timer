using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DiceRoller : MonoBehaviour
{
    [SerializeField]
    GameObject diceOutcomeUI;
    [SerializeField]
    TMP_Text diceOutcomeText;

    [SerializeField]
    int diceSides;

    public void RollDice()
    {
        diceOutcomeUI.SetActive(true);
        diceOutcomeText.text = Random.Range(1, diceSides+1).ToString();
    }
    
    public void CloseDiceWindow()
    {
        diceOutcomeUI.SetActive(false);
    }
}
