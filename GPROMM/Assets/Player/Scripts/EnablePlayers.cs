using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnablePlayers : MonoBehaviour
{
    public void enableBrute()
    {
        GameObject.Find("brute (1)").SetActive(true);
        GameObject.Find("Mage Variant").SetActive(false);
        GameObject.Find("erika_archer_bow_arrow Variant").SetActive(false);
    }

    public void enableMage()
    {
        GameObject.Find("brute (1)").SetActive(true);
        GameObject.Find("Mage Variant").SetActive(true);
        GameObject.Find("erika_archer_bow_arrow Variant").SetActive(false);
    }

    public void enableArcher()
    {
        GameObject.Find("brute (1)").SetActive(false);
        GameObject.Find("Mage Variant").SetActive(false);
        GameObject.Find("erika_archer_bow_arrow Variant").SetActive(true);
    }
}
