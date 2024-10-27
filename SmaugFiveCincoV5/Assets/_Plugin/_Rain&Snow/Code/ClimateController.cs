using UnityEngine;

namespace ClimateController
{
    public class ClimateController : MonoBehaviour
    {
        [Header("Particle System Settings")]
        private ParticleSystem weatherParticles;

        [Header("Shape Settings")]
        [Range(1f, 40f)]
        [SerializeField] private float shapeScaleX = 1f;

        [Header("Collision Settings")]
        [SerializeField] private LayerMask collidesWith;

        private ParticleSystem.ShapeModule shapeModule;
        private ParticleSystem.CollisionModule collisionModule;
        private AudioSource audioSource;

        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
            weatherParticles = GetComponent<ParticleSystem>();
            if (weatherParticles != null)
            {
                shapeModule = weatherParticles.shape;
                collisionModule = weatherParticles.collision;
            }
            else
            {
                Debug.LogWarning("Weather particles not assigned in ClimateController.");
            }
        }

        private void Start()
        {
            PlayMusic();
            UpdateParticleSettings();
        }

        private void UpdateParticleSettings()
        {
            UpdateShapeSettings();
            UpdateCollisionSettings();
        }

        private void UpdateShapeSettings()
        {
            if (weatherParticles != null)
            {
                shapeModule.scale = new Vector3(shapeScaleX, shapeModule.scale.y, shapeModule.scale.z);
            }
        }

        private void UpdateCollisionSettings()
        {
            if (weatherParticles != null)
            {
                collisionModule.collidesWith = collidesWith;
            }
        }

        private void PlayMusic()
        {
            if (audioSource != null)
            {
                audioSource.Play();
            }
            else
            {
                Debug.LogWarning("AudioSource component not found on ClimateController.");
            }
        }
    }
}