using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//For moving Mac going down the slide etc

public class MacController : MonoBehaviour
{
    [SerializeField] private float speed = 3;
    [SerializeField] private GameObject gameCon, canvasCon;

    private WorldMover gameScript;

    private Rigidbody rb;
    private bool isGrounded = false;
    private Vector3 startingPos;

    private void Awake()
    {
        isGrounded = false;
        startingPos = transform.position;
        rb = GetComponent<Rigidbody>();
        if (gameCon != null)
            gameScript = gameCon.GetComponent<WorldMover>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Used to reset the character position 
    public void ResetCharacter()
    {
        gameObject.transform.position = startingPos;
        gameScript.ResetWorld();
        rb.velocity = Vector3.zero;
      
        isGrounded = true;
        //gameCon.GetComponent<MacController>().isGrounded = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            Debug.Log("Here in floor!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            isGrounded = true;
        }
    }

    //for when user falls off the side of the slide
    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Killbox")
        {
            ResetCharacter();
        }
    }

    //hits ice cream or poop
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Here in reset!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
        ResetCharacter();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded)
        {
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
                rb.AddForce(Vector3.right * speed, ForceMode.Impulse);
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
                rb.AddForce(Vector3.left * speed, ForceMode.Impulse);
        }
    }
}
