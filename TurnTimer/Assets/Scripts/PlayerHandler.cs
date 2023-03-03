using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHandler : MonoBehaviour
{
    public static int PlayersInGame = 2;
    public static Color[] playerCols;
    [SerializeField]
    TMP_Text numberOfPlayerText;
    [SerializeField]
    int maxPlayesAllowed = 8;
    [SerializeField]
    int minPlayesAllowed = 2;
    [SerializeField]
    Color[] playerColors;

    [SerializeField]
    GameObject playerUIPrefab;
    [SerializeField]
    Transform playerPanel;
    [SerializeField]
    GameObject setup;

    List<int> playerPoints;

    GameObject[] playerUIs;

    private void Start()
    {
        playerCols = playerColors;
        numberOfPlayerText.text = PlayersInGame.ToString();
        UpdatePlayerUIs();
    }
    // Start is called before the first frame update
    public void ChangePlayerCount(int amount)
    {
        PlayersInGame = Mathf.Clamp(PlayersInGame + amount, minPlayesAllowed, maxPlayesAllowed);
        playerPoints = new List<int>();
        for (int i = 0; i < PlayersInGame; i++)
        {
            playerPoints.Add(0);
        }
        numberOfPlayerText.text = PlayersInGame.ToString();
        UpdatePlayerUIs();
    }
    void UpdatePlayerUIs()
    {
        if(playerUIs != null){
            foreach (GameObject playerUI in playerUIs)
            {
                Destroy(playerUI);
            }
        }
        
        playerUIs = new GameObject[PlayersInGame];
        for (int i = 0; i < PlayersInGame; i++)
        {
            playerUIs[i] = Instantiate(playerUIPrefab, playerPanel);
            playerUIs[i].GetComponent<UIPlayer>().SetColorAndText(playerColors[i],"Player "+(i+1));
        }

    }
    public void DeactivateSetup()
    {
        setup.SetActive(false);
    }
}
