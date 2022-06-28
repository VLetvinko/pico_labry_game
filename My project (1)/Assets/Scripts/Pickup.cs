using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Pickup : MonoBehaviour
{
    [SerializeField]private int gold;
    [SerializeField] private int gems;
    [SerializeField] AudioSource pickupGold;

    private void OnTriggerEnter(Collider other)
    {
        gold = PlayerPrefs.GetInt("Gold");
        gems = PlayerPrefs.GetInt("Gem");

        if (other.gameObject.tag == "Coin")
        {
            pickupGold.Play();
            gold++;
            PlayerPrefs.SetInt("Gold", gold);
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Gem")
        {
            pickupGold.Play();
            gems++;
            PlayerPrefs.SetInt("Gem", gems);
            Destroy(other.gameObject);
        }
    }
}
