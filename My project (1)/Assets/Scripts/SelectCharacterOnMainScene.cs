using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCharacterOnMainScene : MonoBehaviour
{
    private GameObject[] characters;
    private int index;

    [SerializeField] private GameObject target;

    //public Vector3 posPlayer{get;set;}

    // Start is called before the first frame update
    void Start()
    {
        index = PlayerPrefs.GetInt("SelectPlayer");
        
        characters = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            characters[i] = transform.GetChild(i).gameObject;
        }
        foreach (GameObject go in characters)
        go.SetActive(false);
        target.GetComponent<CinemachineTargetGroup>().m_Targets[index].weight = 20;
        if (characters[index])
            characters[index].SetActive(true);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
