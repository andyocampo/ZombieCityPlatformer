using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class KeyTracker : MonoBehaviour
{
    int key;
    int keysInLevel;

    Scene scene;
    [SerializeField] GameObject Text;
    TextMeshProUGUI gasTankText;

    private void Awake()
    {
        key = 0;
        gasTankText = Text.GetComponent<TextMeshProUGUI>();
        scene = SceneManager.GetActiveScene();
        switch (scene.buildIndex)
        {
            case 0:
                keysInLevel = 3;
                break;
            case 1:
                keysInLevel = 5;
                break;
        }
        //Debug.Log($"{scene.buildIndex}");
        gasTankText.text = $"Gas tanks: {key}/{keysInLevel}";
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Key"))
        {
            if (key < keysInLevel)
            {
                Debug.Log("KEY COLLECTED");
                key++;
                gasTankText.text = $"Gas tanks: {key}/{keysInLevel}";
                Destroy(collision.gameObject);
            }
            if(key > keysInLevel-1)
            {
                gasTankText.text = $"Head to helicopter!";
            }
        }
        if (collision.gameObject.CompareTag("Finish") && key == keysInLevel)
        {
            GetComponent<PlayerController>().enabled = false;
            GetComponentInChildren<PlayerLook>().enabled = false;
            gasTankText.text = $"YOU MADE IT!";
            StartCoroutine(switchLevels());
        }
    }

    IEnumerator switchLevels()
    {
        switch (scene.buildIndex)
        {
            case 0:
                yield return new WaitForSeconds(3);
                SceneManager.LoadScene(1);
                break;
            case 1:
                gasTankText.text = $"YOU MADE IT! Press R to restart";
                if (Input.GetKeyDown(KeyCode.R))
                {
                    SceneManager.LoadScene(0);
                }
                break;
        }
    }
}
