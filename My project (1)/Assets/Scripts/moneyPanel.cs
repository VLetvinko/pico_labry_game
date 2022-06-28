using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class moneyPanel : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private TextMeshProUGUI GoldText;
    [SerializeField] private TextMeshProUGUI GemText;

    // Update is called once per frame
    void Update()
    {
        GoldText.text = PlayerPrefs.GetInt("Gold").ToString();
        GemText.text = PlayerPrefs.GetInt("Gem").ToString();
    }
}
