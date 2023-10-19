using UnityEngine;
using UnityEngine.Rendering.Universal;
using System.Collections;
using System.Collections.Generic;

public class PlayerLightManager : MonoBehaviour
{
    public Light2D playerLight;
    public float initialIntensity;
    public float intensityDecrease;
    public float minIntensity;
    public Light2D globalLight;

    private float initialOuterRadius = 5f;
    private float initialGlobalIntensity = 0f;
    private float maximumGlobalIntensity = 0.1f;

    private Coroutine darkenCoroutine = null;
    private Coroutine enlighteningCoroutine = null;

    private void Start()
    {
        initialIntensity = 1f;
        intensityDecrease = 0.1f;
        minIntensity = 0.2f;
    }

    void Update()
    {
        if (GetIntensity() <= minIntensity && enlighteningCoroutine == null)
        {
            StartEnvironmentTransition(5.0f, false);
        }
        else if (GetIntensity() > minIntensity && globalLight.intensity > initialGlobalIntensity && darkenCoroutine == null)
        {
            StartEnvironmentTransition(5.0f, true);
        }
    }

    // Coroutine to change the environment light (darken or illuminate)
    private IEnumerator ChangeEnvironmentLight(float targetIntensity, float transitionDuration, bool darken)
    {
        float elapsedTime = 0f;
        float startIntensity = globalLight.intensity;

        while (elapsedTime < transitionDuration)
        {
        
            float newIntensity = Mathf.Lerp(startIntensity, targetIntensity, elapsedTime / transitionDuration);
            globalLight.intensity = newIntensity;
           

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        globalLight.intensity = targetIntensity;

        if (darken) 
        {
            darkenCoroutine = null;
        }
        else 
        {
            enlighteningCoroutine = null;
        }
    }

    // Start a new environment transition
    private void StartEnvironmentTransition(float duration, bool darken)
    {
        if (darkenCoroutine != null && !darken)
        {
            StopCoroutine(darkenCoroutine);
            darkenCoroutine = null;
        }
        else if (enlighteningCoroutine != null && darken)
        {
            StopCoroutine(enlighteningCoroutine);
            enlighteningCoroutine = null;
        }

        if (darken)
        {
            darkenCoroutine = StartCoroutine(ChangeEnvironmentLight(initialGlobalIntensity, duration, darken));

        }
        else
        {
            enlighteningCoroutine = StartCoroutine(ChangeEnvironmentLight(maximumGlobalIntensity, duration, darken));
        }
    }

    public void InitializeLight()
    {
        playerLight.intensity = initialIntensity;
        playerLight.pointLightOuterRadius = initialOuterRadius;
    }

    public void DecreaseLight()
    {
        if (playerLight.intensity > minIntensity)
        {
            playerLight.intensity -= intensityDecrease;
            playerLight.pointLightOuterRadius = playerLight.intensity * initialOuterRadius;
        }
    }

    public void IncreaseLight(float amount)
    {
        playerLight.intensity += amount;
        playerLight.pointLightOuterRadius = playerLight.intensity * initialOuterRadius;
    }

    public float GetIntensity()
    {
        return playerLight.intensity;
    }

    public bool CanShoot()
    {
        return playerLight.intensity > minIntensity;
    }
}
