using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * This script contains the behavior for the pause menu
 * buttons that appear when hitting the ESC key in-game.
 */

/*
 * Meant to be used with script PauseMenuManager.cs
 * where this script is to be components of the pause
 * menu buttons, and the Manager script is the
 * component of the Canvas that houses the buttons.
 */
 
public class PauseMenuButtons : MonoBehaviour
{
    public Canvas _menu;
    
    /*
     * Resume game OnClick()
     */
    public void Resume()
    {
        _menu.enabled = !_menu.enabled; // Hide the menu
        
        Time.timeScale = 1.0f;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.lockState = CursorLockMode.None;
        Cursor.lockState = CursorLockMode.Locked;
    }

    /*
     * Restart game OnClick()
     */
    public void RestartGame()
    {
        Debug.Log("Restart");
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(4);
    }
    
    
    // Exit to title screen
    public void ReturnToTitle()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }
}
