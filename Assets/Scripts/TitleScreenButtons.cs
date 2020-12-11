using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenButtons : MonoBehaviour
{
    public void PlayButtonPressed()
    {
        SceneManager.LoadScene(1);
    }

    public void CreditsButtonPressed()
    {

    }

    public void QuitButtonPressed()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }
}
