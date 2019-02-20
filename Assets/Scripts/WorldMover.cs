using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMover : MonoBehaviour
{
    #region Serialized Fields

    [SerializeField] private List<GameObject> slides = new List<GameObject>();

    [SerializeField] private GameObject macGo, canvasGO;

    [SerializeField] private Transform groundTrans;

    [SerializeField] private float lerpSpeed = 5, lengthFlo;

    [SerializeField] int slideChildGOs, lengthInt;

    [SerializeField] Vector3 length;

    #endregion

    private bool isGrounded;

    bool repeat;

    private Vector3 startingPos;

    // how do i get the player to tell the game con to update the canvas?
    public void CallCanvas(string words)
    {

    }

    private void Awake()
    {
        groundTrans = this.transform.GetChild(0);

        repeat = true;
        isGrounded = false;
        startingPos = transform.position;
        slideChildGOs = groundTrans.childCount;
        //lengthFlo = groundTrans.GetChild(0).gameObject.GetComponentInChildren<MeshCollider>().bounds.size.y;
    }

    void Start()
    {
        //StartCoroutine(WaitAndMove(1f, slideChildGOs));
        StartCoroutine(ContinuouslyMove(slideChildGOs));
    }

    void Update()
    {
        //https://www.unity3dtips.com/unity-fix-movement-stutter/
        //not this one -- transform.position = Vector3.Lerp(transform.position, Vector3.back * 300, (Time.deltaTime * lerpSpeed)/100f);
        //transform.position += Vector3.back * (lerpSpeed / 10);
    }

    public void ResetWorld()
    {
        //macGO.GetComponent<MacController>().ResetCharacter();
        transform.position = startingPos;
    }
    
    private IEnumerator ContinuouslyMove(int slideCount)
    {
        while(repeat)
        {
            slideCount++;
            if (slideCount > slideChildGOs - 1)
                slideCount = 0;

            groundTrans.GetChild(slideCount).transform.position += Vector3.back * 50f * Time.deltaTime;
            yield return new WaitForSeconds(Time.smoothDeltaTime);
        }
    }


    // loop through background
    private IEnumerator WaitAndMove(float time, int slideCount)
    {
        //Debug.Log("SlideCount before: " + slideCount);

        while (repeat)
        {
            slideCount++;
            // Subtracting 1 because we start counting from 0 but we count the GO starting at 1 
            if (slideCount > slideChildGOs - 1)
            {
                slideCount = 0;
            }
        
            groundTrans.GetChild(slideCount).transform.position += new Vector3(0, 0, 230f);

            Debug.Log("SlideCount after: " + slideCount);
            yield return new WaitForSeconds(2f);
        }

        groundTrans.GetChild(slideCount);

        Debug.Log("SlideParts 0: " + slides[0].gameObject.name);
        Debug.Log("SlidePart Capacity: " + (slides.Capacity));
        Debug.Log("First Child: " + groundTrans.GetChild(0).name);

        yield return new WaitForSeconds(time);
    }
}
