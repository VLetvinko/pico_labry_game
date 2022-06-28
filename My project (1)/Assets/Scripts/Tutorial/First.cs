using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class First : MonoBehaviour
{
    [SerializeField] public GameObject pauseMenu;

    private void Start()
    {
        pauseMenu.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        pauseMenu.SetActive(true);
    }

    public void close()
    {
        pauseMenu.SetActive(false);
    }

}
