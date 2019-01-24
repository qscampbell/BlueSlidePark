using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMover : MonoBehaviour
{
    #region Serialized Fields

    [SerializeField] private Transform[] groundObjects;

    [SerializeField] private GameObject macGo;

    [SerializeField] private float lerpSpeed = 5;

    #endregion

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
        WaitAndMove(5f, groundObjects);
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

    // loop through background
    private IEnumerator WaitAndMove(float time, Transform[] slideParts)
    {
        


        yield return new WaitForSeconds(time);
    }
}
