using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// TODO:
///     - Pull menu controller from Spose game
///     - Use GUI.Box to create a box for inputting the user's name on MainMenu
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
    [SerializeField] private GameObject inputText;
    private bool flag = true, enterPressed = false;
    public void Update()
    {
        if (flag)
        {
            box = GameObject.Find("MainBox");
            spaceTxt = GameObject.Find("pressSpaceTxt");
            inputText = GameObject.Find("nameText");
            flag = false;
            spaceTxt.SetActive(false);
        }
        if (Input.GetKey(KeyCode.Return))//user has pressed enter
        {
            //testing
            //inputText.GetComponent<Text>().text = "Hello World";
            
            box.SetActive(false); //hide the box
            spaceTxt.SetActive(true); //show the text
            enterPressed = true;

        }
        else if (Input.GetKey(KeyCode.Space) && enterPressed)
        {
            spaceTxt.SetActive(true);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }


    public void DisplayNewUI(string option)
    {
        switch (option)
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

    //testing

}
