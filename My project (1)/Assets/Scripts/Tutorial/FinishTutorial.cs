using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishTutorial : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            PlayerPrefs.SetInt("SelectPlayer", 0);
            PlayerPrefs.SetInt("Tutorial", 1);
            SceneManager.LoadScene(0);
        }
    }
}
