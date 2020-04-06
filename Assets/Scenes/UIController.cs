using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// TODO:
///     - Pull menu controller from Spose game
/// </summary>

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject txtBox;

    public void LoadSceneButton()
    {
        Debug.Log("Test: " + name);

        txtBox = GameObject.Find("nameText");
        Debug.Log("Tag: " + txtBox.tag);

        Debug.Log("Text: " + txtBox.GetComponent<Text>().text);

        //need to fix to get the correct text
        txtBox.GetComponent<Text>().text = "primetime43";

        /*if (Input.GetKey(KeyCode.Return))
        {
            Debug.Log("Enter");
        }*/
    }

    [SerializeField] private GameObject box;
    [SerializeField] private GameObject spaceTxt;
    private bool flag = true;
    public void Update()
    {
        if (flag)
        {
            box = GameObject.Find("MainBox");
            spaceTxt = GameObject.Find("pressSpaceTxt");
            flag = false;
            spaceTxt.SetActive(false);
        }
        if (Input.GetKey(KeyCode.Return))
        {
            box.SetActive(false); //hide the box
            spaceTxt.SetActive(true); //show the text
        }
        else if(Input.GetKey(KeyCode.Space))
        {
            spaceTxt.SetActive(true);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }


    public void DisplayNewUI(string option)
    {
        switch(option)
        {
            case "music player":
                // Should this be it's own scene?
                print("show UI for music player...");
                break;

            case "options":
                print("show UI for options...");
                break;

            case "quit":
                print("are you sure?...");
                break;
         
        }


          
    }

}
