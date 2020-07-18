using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * This script contains the behavior for opening up the 
 * pause menu in-game.
 */

/*
 * Meant to be used with script PauseMenuButtons.cs
 * where this script is the component of the Canvas that
 * houses the buttons, and the Buttons script is
 * to be components of the pause menu buttons.
 */

/*
 * ###### NOTE: IF USING FIRSTPERSONCONTROLLER.CS FROM STANDARD ASSETS FOR UNITY ######
 * --------------------------------------------------------------------------
 *         Under the private method RotateView()
 *         place a check for Time.deltaTime being 0.0f.
 *         i.e.,
 *                 if(Time.deltaTime == 0.0f){
 *                     return;
 *                  } 
 * 
 *         This check will prevent the camera from moving while
 *         the game is paused.
 */

public class PauseMenuManager : MonoBehaviour
{
    private Canvas _menu;
    public Camera firstPersonCamera;
    
    // Start is called before the first frame update
    void Start()
    {
        _menu = GetComponent<Canvas>();
        _menu.enabled = false;
        // Just in case player does Pause->Exit->Start Game because it WILL stay at timeScale = 0.0f
        Time.timeScale = 1.0f; 
        //firstPersonCamera = gameObject.Find("FirstPersonCharacter").GetComponent(m_MouseLook);
    }

    
    // Update is called once per frame
    void Update()
    {
        // Show pause menu on ESC and hide it on ESC again
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            _menu.enabled = !_menu.enabled;
            if (_menu.enabled == true)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Time.timeScale = 0.0f;
            }
            else
            {
                //Cursor.lockState = CursorLockMode.None;
                Cursor.lockState = CursorLockMode.Locked;
                Time.timeScale = 1.0f;
            }
        }
    }

}
