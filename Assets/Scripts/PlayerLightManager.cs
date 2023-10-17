using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerLightManager : MonoBehaviour
{
    public Light2D playerLight;
    public float initialIntensity = 1f;
    public float intensityDecrease = 0.1f;
    public float minIntensity = 0.0f;

    private float initialOuterRadius;

    private void Start()
    {
        initialOuterRadius = playerLight.pointLightOuterRadius;
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
}
