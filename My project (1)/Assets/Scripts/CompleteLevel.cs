using UnityEngine;
using UnityEngine.SceneManagement;

public class CompleteLevel : MonoBehaviour
{
    private int gold;
    private int gems;
    private void OnTriggerEnter(Collider other)
    {
        gold = PlayerPrefs.GetInt("Gold");
        gems = PlayerPrefs.GetInt("Gem");
        if (other.transform.tag == "Player")
        {
            if (SceneManager.GetActiveScene().name == "SampleScene")
            {
                if (PlayerPrefs.GetInt("currentLevel") >= PlayerPrefs.GetInt("GlobalLevel"))
                {
                    PlayerPrefs.SetInt("GlobalLevel", PlayerPrefs.GetInt("currentLevel") + 1);
                }
                PlayerPrefs.SetString("CurrentScene", SceneManager.GetActiveScene().name);
                SceneManager.LoadScene(5);
            }
            else if(SceneManager.GetActiveScene().name == "ProceduralScene")
            {
                PlayerPrefs.SetString("CurrentScene", SceneManager.GetActiveScene().name);
                gold = gold + 100;
                gems = gems + 10;
                PlayerPrefs.SetInt("Gold", gold);
                PlayerPrefs.SetInt("Gem", gems);
                SceneManager.LoadScene(5);
            }

            Destroy(gameObject);
        }
    }
}
