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

    private bool isGrounded, repeat = true;
    private Vector3 startingPos;

    private void Awake()
    {
        groundTrans = this.transform.GetChild(0);
        isGrounded = false;

        // Count the slides
        SlideCounter();  
    }

    void Start()
    {
        AlignSlide();
       
    }

    void Update()
    {
 
    }

    void AlignSlide()
    {
        

    }

    public void ResetWorld()
    {
        //macGO.GetComponent<MacController>().ResetCharacter();
        transform.position = startingPos;
    }


    // Literally just count the slides and get the length of them individually as well as a whole
    private void SlideCounter()
    {
        // This adds the slides gameobjects to the list, gets their size, sets them to zero, then spans them out evenly
        int count = 0;
        foreach (Transform child in groundTrans)
        {
            
            slides.Add(groundTrans.GetChild(count).gameObject);

            slides[count].GetComponent<Transform>().position = Vector3.zero;

            if(count != 0)
                slides[count].GetComponent<Transform>().position = new Vector3(0,0,(slides[count - 1].GetComponentInChildren<Collider>().bounds.size.z) * count);

            Debug.Log("Slide " + count + ": " + slides[count].GetComponentInChildren<Collider>().bounds.size);

            count++;
        }

        



        // Now, go to the first child in each slide, and return the bounds of the child
    }
    
    private IEnumerator ContinuouslyMove(int slideCount)
    {
        //float step = (lerpSpeed / (groundTrans.GetChild(slideCount).transform.position - Vector3.back * 300).magnitude) * Time.fixedDeltaTime;
        float t = 0;

        while (repeat)
        {
            slideCount++;
            if (slideCount > slideChildGOs - 1)
                slideCount = 0;
            t += Time.deltaTime; // Goes from 0 to 1, incrementing by step each time
            groundTrans.GetChild(slideCount).transform.position = Vector3.Lerp(groundTrans.GetChild(slideCount).transform.position, Vector3.back * 800, (Time.deltaTime * lerpSpeed) / 100f); // Move objectToMove closer to b
            //yield return new WaitForFixedUpdate();
            //groundTrans.GetChild(slideCount).transform.position += Vector3.back * 50f * Time.deltaTime;
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
