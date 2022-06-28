using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Istutorial : MonoBehaviour
{
    [SerializeField] private GameObject LevelsButton;
    [SerializeField] private GameObject TutorialButton;
    [SerializeField] private GameObject RandomButton;
    [SerializeField] private GameObject ShopButton;
    void Start()
    {
        if (PlayerPrefs.GetInt("Tutorial") == 0)
        {
            LevelsButton.SetActive(false);
            RandomButton.SetActive(false);
            ShopButton.SetActive(false);
            TutorialButton.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
