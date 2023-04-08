using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneController : MonoBehaviour
{
    [SerializeField]
    private string _sceneName;

    public void LoadScene()
    {
        SceneManager.LoadScene(_sceneName);
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
