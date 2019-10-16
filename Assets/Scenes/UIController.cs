using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// TODO:
///     - Pull menu controller from Spose game
/// </summary>

public class UIController : MonoBehaviour
{
    public void LoadSceneButton(string name)
    {
        SceneManager.LoadScene(name, LoadSceneMode.Single);
        
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
