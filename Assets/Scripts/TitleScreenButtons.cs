using Cinemachine;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenButtons : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera mainVCam, creditsVCam;
    [SerializeField] GameObject menuButtons, backButton;

    private readonly int onPriority = 100, offPriority = 0;

    private void Start()
    {
        mainVCam.Priority = onPriority;
        creditsVCam.Priority = offPriority;
    }

    public void PlayButtonPressed()
    {
        SceneManager.LoadScene(1);
    }

    public void CreditsButtonPressed()
    {
        menuButtons.SetActive(false);
        StartCoroutine(SetActiveAfterSeconds(backButton, true, 2));
        mainVCam.Priority = offPriority;
        creditsVCam.Priority = onPriority;
    }

    public void QuitButtonPressed()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }

    public void BackButtonPressed()
    {
        backButton.SetActive(false);
        StartCoroutine(SetActiveAfterSeconds(menuButtons, true, 2));
        creditsVCam.Priority = offPriority;
        mainVCam.Priority = onPriority;
    }

    IEnumerator SetActiveAfterSeconds(GameObject g, bool val, float s)
    {
        yield return new WaitForSeconds(s);
        g.SetActive(val);
    }
}
