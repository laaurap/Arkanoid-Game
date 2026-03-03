using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    public string firstLevelScene = "tela1";

    public void Play()
    {
        SceneManager.LoadScene(firstLevelScene);
    }

    public void Quit()
    {
        Application.Quit();
    }
}