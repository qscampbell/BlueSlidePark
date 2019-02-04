using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMover : MonoBehaviour
{
    #region Serialized Fields

    [SerializeField] private List<GameObject> slides = new List<GameObject>();

    [SerializeField] private GameObject macGo, canvasGO;

    [SerializeField] private Transform groundTrans;

    [SerializeField] private float lerpSpeed = 5;

#endregion

    private bool isGrounded;

    private Vector3 startingPos;

    // how do i get the player to tell the game con to update the canvas?
    public void CallCanvas(string words)
    {

    }

    private void Awake()
    {
        groundTrans = this.transform.GetChild(0);
    

        isGrounded = false;
        startingPos = transform.position;

    
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitAndMove(5f, slides));
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
    private IEnumerator WaitAndMove(float time, List<GameObject> slideParts)
    {
        // populate the list of gameobjects
        if(slideParts.Capacity == 0)
        {
            foreach(Transform child in groundTrans)
            {
                slideParts.Add(child.gameObject);
            }
           // Debug.Log("Slidepart Capacity: " + slideParts.Capacity);
        }
        else
        {
            //Debug.Log("Exit");
        }

        slideParts[slideParts.Capacity - 2].transform.position = new Vector3(0f, 0f, 170f);
        Debug.Log("SlidePart Capacity: " + (slideParts.Capacity - 2));
        
        slideParts[slideParts.Capacity - 2].transform.SetSiblingIndex(0);
        Debug.Log("First Child: " + )



        yield return new WaitForSeconds(time);

        //Loop
        StartCoroutine(WaitAndMove(5f, slideParts));
    }
}
