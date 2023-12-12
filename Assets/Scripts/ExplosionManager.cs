using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExplosionManager : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("pipe"))
        {
            Debug.Log("explode!");

            // Find and play the explosion GameObject
            GameObject explosionObject = GameObject.FindWithTag("explosion");

            if (explosionObject != null)
            {
                // Assuming the explosion is controlled by a Particle System component
                ParticleSystem explosionParticleSystem = explosionObject.GetComponent<ParticleSystem>();

                if (explosionParticleSystem != null)
                {
                    // Play the explosion particle system
                    explosionParticleSystem.Play();

                    // Wait for the duration of the explosion
                    StartCoroutine(ReloadSceneAfterExplosion(explosionParticleSystem.main.duration));
                }
                else
                {
                    Debug.LogError("The GameObject with tag 'explosion' does not have a ParticleSystem component.");
                }
            }
            else
            {
                Debug.LogError("No GameObject found with tag 'explosion'.");
            }
        }
    }

    IEnumerator ReloadSceneAfterExplosion(float delay)
    {
        // Wait for the specified duration
        yield return new WaitForSeconds(delay);

        // Reload the current scene
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}