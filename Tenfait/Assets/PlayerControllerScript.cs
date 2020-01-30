using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour
{

    public Camera camera;
    public Canvas headUpDisplay;

    public GameObject playerStatsMenuPrefab;
    public PlayerStatsMenuScript playerStatsMenu;

    public string description;

    public int playerHP;
    public int playerMaxHP;
    public int playerMana;
    public int playerMaxMana;

    private float movementSpeed = 5.0f;
    private float rotationSpeed = 1.0f;
    private float jumpCooldown = 0.5f;
    public float jumpCooldownTimer = 0f;
    public bool onGround;

    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponentInChildren<Camera>();
        onGround = true;
        headUpDisplay = GameObject.FindGameObjectWithTag("HeadUpDisplay").GetComponent<Canvas>();
        playerHP = 100;
        playerMaxHP = 200;
        playerMana = 50;
        playerMaxMana = 100;
    }

    private void FixedUpdate()
    {
        if (jumpCooldownTimer > 0)
        {
            jumpCooldownTimer -= Time.deltaTime;

        }

        if (jumpCooldownTimer < 0)
        {
            jumpCooldownTimer = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        if (inputY != 0)
        {
            transform.position = transform.position + (transform.forward * inputY) * movementSpeed * Time.deltaTime;
        }

        if (inputX != 0)
        {
            transform.Rotate(new Vector3(0, inputX, 0) * rotationSpeed);
        }
        else
        {
            transform.Rotate(new Vector3(0, 0, 0));
        }

        if (Input.GetAxis("Jump") > 0 && jumpCooldownTimer == 0 && onGround)
        {
            GetComponentInChildren<Rigidbody>().AddForce(new Vector3(0, 500f, 0), ForceMode.Impulse);
            jumpCooldownTimer = jumpCooldown;
            onGround = false;
        }

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 7.0f))
            {
                if (hit.transform.gameObject.GetComponent<NPCControllerScript>().popUp == null)
                {
                    hit.transform.gameObject.SendMessage("OpenTalkMenu");
                }
                //Debug.Log("You selected the " + hit.transform.name); // ensure you picked right object
            }
        }

        if (Input.GetKeyDown(KeyCode.P) && playerStatsMenu == null)
        {
            playerStatsMenu = Instantiate(playerStatsMenuPrefab, FindObjectOfType<Canvas>().transform).AddComponent<PlayerStatsMenuScript>();
            playerStatsMenu.player = this;
        }

    }

    void OnCollisionEnter(Collision other)
    {
        //this is when i touch the ground i am able to jump but i will add the 5 second delay lyaer
        if (other.gameObject.CompareTag("Terrain"))
        {
            onGround = true;
        }
    }
}
