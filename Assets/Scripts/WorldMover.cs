using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMover : MonoBehaviour
{

    [SerializeField] Transform[] groundObjects;
    [SerializeField] private GameObject macGO;
    [SerializeField] private float lerpSpeed = 5;

    private bool isGrounded;
    private Vector3 startingPos;

    private void Awake()
    {
        startingPos = transform.position;
        isGrounded = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Vector3.back * 20f * Time.deltaTime);
        //https://www.unity3dtips.com/unity-fix-movement-stutter/
        transform.position = Vector3.Lerp(transform.position, Vector3.back * 300, (Time.deltaTime * lerpSpeed)/100f);
    }

    public void ResetWorld()
    {
        //macGO.GetComponent<MacController>().ResetCharacter();
        transform.position = startingPos;
    }
}
