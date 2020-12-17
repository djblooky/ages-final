using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private float transitionTime = 2f;
    private Animator animator;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }
    
    public void StartFadeToBlack()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0){
            StartCoroutine(LoadLevel(1));
        }
        else if(SceneManager.GetActiveScene().buildIndex == 1){
            StartCoroutine(LoadLevel(0));
        }
        
    }

    IEnumerator LoadLevel(int index)
    {
        animator.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(index);
    }

    private void OnEnable() 
    {
        EndCreditsTrigger.EndCreditsTriggered += StartFadeToBlack;
    }

    private void OnDisable() 
    {
        EndCreditsTrigger.EndCreditsTriggered -= StartFadeToBlack;
    }

}
