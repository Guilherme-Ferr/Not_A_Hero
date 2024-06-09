using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightFlicker : MonoBehaviour
{
    // Referência à luz 2D
    private Light2D light2D;

    // Intensidade base da luz
    public float baseIntensity = 1.0f;

    // Variância máxima da intensidade
    public float flickerAmount = 0.5f;

    // Frequência do flicker
    public float flickerSpeed = 0.1f;

    // Raio externo base da luz
    public float baseOuterRadius = 5.0f;

    // Variância máxima do raio externo
    public float radiusFlickerAmount = 0.5f;

    private void Start()
    {
        // Obtém a referência à luz 2D anexada ao objeto
        light2D = GetComponent<Light2D>();
    }

    private void Update()
    {
        if (light2D != null)
        {
            // Calcula a nova intensidade da luz
            float noise = Mathf.PerlinNoise(Time.time * flickerSpeed, 0.0f);
            light2D.intensity = baseIntensity + noise * flickerAmount;

            // Calcula o novo raio externo da luz
            light2D.pointLightOuterRadius = baseOuterRadius + noise * radiusFlickerAmount;
        }
    }
}
