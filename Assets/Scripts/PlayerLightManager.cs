using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerLightManager : MonoBehaviour
{
    public Light2D playerLight;
    public float initialIntensity;
    public float intensityDecrease;
    public float minIntensity;

    private float initialOuterRadius = 5f;

    private void Start()
    {
        initialIntensity = 1f;
        intensityDecrease = 0.1f;
        minIntensity = 0.15f;
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
