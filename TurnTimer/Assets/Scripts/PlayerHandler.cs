using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    public static int MaxPlayers;

    [SerializeField]
    int NumberOfPlayers;

    List<int> playerPoints = new List<int>();
    // Start is called before the first frame update
    void Awake()
    {
        MaxPlayers = NumberOfPlayers;
        for (int i = 0; i < NumberOfPlayers; i++)
        {
            playerPoints.Add(0);
        }
    }
}
