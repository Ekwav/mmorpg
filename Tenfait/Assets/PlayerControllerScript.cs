using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour
{

    public Camera camera;

    private float movementSpeed = 5.0f;
    private float rotationSpeed = 5.0f;
    private float jumpCooldown = 0.5f;
    public float jumpCooldownTimer = 0f;
    public bool onGround;

    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponentInChildren<Camera>();
        onGround = true;

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
        float inputR = Mathf.Clamp(Input.GetAxis("Mouse X"), -1.0f, 1.0f);

        if (Input.GetAxis("Jump") > 0 && jumpCooldownTimer == 0 && onGround)
        {
            GetComponentInChildren<Rigidbody>().AddForce(new Vector3(0, 500f, 0), ForceMode.Impulse);
            jumpCooldownTimer = jumpCooldown;
            onGround = false;
        }

        // get current position, then do calculations
        Vector3 moveVectorX = transform.forward * inputY;
        Vector3 moveVectorY = transform.right * inputX;
        Vector3 moveVector = (moveVectorX + moveVectorY) * movementSpeed * Time.deltaTime;

        // update Character position and rotation
        transform.position = transform.position + moveVector;
        transform.Rotate(new Vector3(0, inputX, 0) * rotationSpeed);

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 10.0f))
            {
                hit.transform.gameObject.SendMessage("OpenTalkMenu");
                Debug.Log("You selected the " + hit.transform.name); // ensure you picked right object
            }
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
