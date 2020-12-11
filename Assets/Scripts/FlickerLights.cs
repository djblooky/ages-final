using System.Collections;
using UnityEngine;

public class FlickerLights : MonoBehaviour
{
    [SerializeField] AudioClip flickerSound;
    [SerializeField] private float delayBetweenFlickers = 10;
    [SerializeField] private Light[] lightsToFlicker;

    private bool couroutineRunning = false;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (!couroutineRunning)
        {
            StartCoroutine(Flicker());
            couroutineRunning = true;
        }
    }

    private IEnumerator Flicker()
    {
        yield return new WaitForSeconds(delayBetweenFlickers);

        audioSource.PlayOneShot(flickerSound);

        TurnLightsOff();
        yield return new WaitForSeconds(0.1f);
        TurnLightsOn();

        yield return new WaitForSeconds(0.2f);

        TurnLightsOff();
        yield return new WaitForSeconds(0.1f);
        TurnLightsOn();

        couroutineRunning = false;
    }

    private void TurnLightsOff()
    {
        foreach (Light light in lightsToFlicker)
        {
            light.enabled = false;
        }
    }

    private void TurnLightsOn()
    {
        foreach (Light light in lightsToFlicker)
        {
            light.enabled = true;
        }
    }
}
