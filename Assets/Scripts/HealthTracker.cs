using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class HealthTracker : MonoBehaviour
{
    float health = 100;

    [SerializeField] GameObject Text;
    TextMeshProUGUI healthText;
    Scene scene;

    void Start()
    {
        healthText = Text.GetComponent<TextMeshProUGUI>();
        scene = SceneManager.GetActiveScene();
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            health--;
            healthText.text = $"Health: {health}";
            if(health <= 0)
            {
                GetComponent<PlayerController>().enabled = false;
                GetComponentInChildren<PlayerLook>().enabled = false;
                health = 0;
                healthText.text = $"Health: {health} GAME OVER. Press R to restart";
                if (Input.GetKeyDown(KeyCode.R))
                {
                    SceneManager.LoadScene(scene.buildIndex);
                }
            }
        }
    }

}
