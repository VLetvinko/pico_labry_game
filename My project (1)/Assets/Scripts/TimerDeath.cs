using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerDeath : MonoBehaviour
{
    public float timerStart = 60;

    public TextMeshProUGUI textTimer;

    void Start()
    {
        textTimer.text = timerStart.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        timerStart -= Time.deltaTime;
        textTimer.text = Mathf.Round(timerStart).ToString();
        if (timerStart <= 0)
        {
            PlayerPrefs.SetString("CurrentScene", SceneManager.GetActiveScene().name);
            SceneManager.LoadScene(6);
        }
    }
}
