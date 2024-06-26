using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour {
    public void ReloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
}
