using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenBehavior : MonoBehaviour
{
    /*
     *                 FOR REFERENCE
     * --------------------------------------------------
     * <Component>                         -- <normal color> | <highlighted button color>
     * Title screen background hex         -- 261941
     * Start button hex                    -- 9EE788 | 689C65
     * Options button hex                  -- CCAB6B | 907C73
     * Exit button hex                     -- B44A4B | 65292A
     * About button hex                    -- A687BC | 582760
     * Credits button hex                  -- 8792BC | 273060
     *
     * Title screen title font: Unipix
     * Title screen title size: 80
     * About/Credit screen title coords: (-280, 170, 0)
     * About/Credit screen text coords: (-237, -10, 0)
     * About/Credit screen text size: 30
     * About/Credit screen (all) text font: Unipix
     *         (may make Credits text hard to read, let Ali know or
     *                     change it to OpenSansRegular/Bold/SemiBold/etc.)
     *
     * Button size (All):
     *     W: 160
     *     H: 40
     *
     * About Button Coords (for Back Buttons on About/Credit/Option Scenes):
     *     X = -290
     *     Y = -200
     *     Text Size: 18
     *     Text Font: OpenSansRegular
     *
     * About Font Size:  
     * About Text Size: 
     */
    
    public void ToStart()
    {
        SceneManager.LoadScene(4);
    }

    
    
    public void ToExit()
    {
        Application.Quit();
    }

    

    public void ToOptions()
    {
        SceneManager.LoadScene(3);
    }



    public void ToAbout()
    {
        SceneManager.LoadScene(1);
    }



    public void ToCredits()
    {
        SceneManager.LoadScene(2);
    }
    
}
