using TMPro;
using UnityEngine;

public class GemPickUp : MonoBehaviour
{
    [SerializeField] private int gems;

    private void OnTriggerEnter(Collider other)
    {
        gems = PlayerPrefs.GetInt("Gem");
        if (other.gameObject.tag == "Player")
        {
            gems++;
            PlayerPrefs.SetInt("Gem", gems);
            Destroy(gameObject);
        }

    }
}
