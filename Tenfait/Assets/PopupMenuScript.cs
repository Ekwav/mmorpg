using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupMenuScript : MonoBehaviour
{

    public Button exitButton;
    public Text headLine;
    public Text description;

    public NPCControllerScript npc;

    // Start is called before the first frame update
    void Start()
    {
        exitButton = GameObject.Find("Exit_Button").GetComponent<Button>();
        exitButton.onClick.AddListener(ClosePopup);
        if (npc != null)
        {
            headLine = GameObject.Find("MenuHeadLine").GetComponent<Text>();
            headLine.text = npc.gameObject.name;
            description = GameObject.Find("DescriptionText").GetComponent<Text>();
            description.text = npc.description;
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
