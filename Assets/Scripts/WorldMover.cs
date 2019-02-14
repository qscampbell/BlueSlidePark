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
        
        //Get number of children and length of them
       

    }

    void Start()
    {
        StartCoroutine(WaitAndMove(1f, slideChildGOs));
    }

    void Update()
    {

        //https://www.unity3dtips.com/unity-fix-movement-stutter/
        //transform.position = Vector3.Lerp(transform.position, Vector3.back * 300, (Time.deltaTime * lerpSpeed)/100f);
        transform.position += Vector3.back * (lerpSpeed / 10);
    }

    public void ResetWorld()
    {
        //macGO.GetComponent<MacController>().ResetCharacter();
        transform.position = startingPos;
    }


    
    // loop through background
    private IEnumerator WaitAndMove(float time, int slideCount)
    {
        Debug.Log("SlideCount before: " + slideCount);

        // Subtracting 1 because we start counting from 0 but we count the GO starting at 1
      

        while (repeat)
        {
            slideCount++;
            if (slideCount > slideChildGOs - 1)
            {
                slideCount = 0;
            }

            groundTrans.GetChild(slideCount).transform.position += new Vector3(0, 0, 458f);

            Debug.Log("SlideCount after: " + slideCount);
           

            //Debug.Log("OnCoroutine: " + (int)Time.time);
            yield return new WaitForSeconds(2f);
        }

        groundTrans.GetChild(slideCount);

        //slides[slideCount].transform.position += new Vector3(100f, 0f, 170f);


     


        //if (slideCount > slides.Capacity - 1)
          //  slideCount = 0;

        Debug.Log("SlideParts 0: " + slides[0].gameObject.name);

        Debug.Log("SlidePart Capacity: " + (slides.Capacity));

        //slideParts[slideParts.Capacity - 2].transform.SetSiblingIndex(0);
        Debug.Log("First Child: " + groundTrans.GetChild(0).name);


        yield return new WaitForSeconds(time);
    }
}
