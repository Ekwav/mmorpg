using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsMenuScript : MonoBehaviour
{
    public Button exitButton;
    public Text playerName;
    public Text description;

    public Text hpValueText;
    public GameObject hpBar;
    public Text manaValueText;
    public GameObject manaBar;

    public PlayerControllerScript player;

    // Start is called before the first frame update
    void Start()
    {
        exitButton = GameObject.Find("Exit_Button").GetComponent<Button>();
        exitButton.onClick.AddListener(ClosePopup);
        playerName = GameObject.Find("PlayerName").GetComponent<Text>();
        description = GameObject.Find("PlayerDescription").GetComponent<Text>();
        hpValueText = GameObject.Find("HPValueText").GetComponent<Text>();
        hpBar = GameObject.Find("HPBar");
        manaValueText = GameObject.Find("ManaValueText").GetComponent<Text>();
        manaBar = GameObject.Find("ManaBar");

        if (player != null)
        {
            playerName.text += player.gameObject.name;
            description.text = player.description;
            hpValueText.text = $"{player.playerHP} / {player.playerMaxHP}";
            hpBar.transform.localScale = new Vector3(player.playerHP / (player.playerMaxHP / 100.0f) / 100, 1f);
            manaValueText.text = $"{player.playerMana} / {player.playerMaxMana}";
            manaBar.transform.localScale = new Vector3(player.playerMana / (player.playerMaxMana / 100.0f) / 100, 1f);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ClosePopup()
    {
        Destroy(gameObject);
    }
}
