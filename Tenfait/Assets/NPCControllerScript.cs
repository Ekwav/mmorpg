using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCControllerScript : MonoBehaviour
{

    public GameObject popupMenuPrefab;
    public string description;

    public PopupMenuScript popUp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if(popUp != null) if (popUp.npc == null) popUp.npc = this;
    }

    void OpenTalkMenu()
    {
        popUp = Instantiate(popupMenuPrefab, FindObjectOfType<Canvas>().transform).AddComponent<PopupMenuScript>();
        popUp.npc = this;
    }

    private void OnTriggerExit(Collider other)
    {
        if (popUp != null)
        {
            Destroy(popUp.gameObject);
        } 
    }
}
