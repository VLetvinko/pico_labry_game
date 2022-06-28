using UnityEngine;
using UnityEngine.SceneManagement;

public class Deadplayer : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            PlayerPrefs.SetString("CurrentScene", SceneManager.GetActiveScene().name);
            SceneManager.LoadScene(6);
        }
    }
}
