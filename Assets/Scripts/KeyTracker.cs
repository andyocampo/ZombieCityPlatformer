using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyTracker : MonoBehaviour
{
    int key;
    [SerializeField] GameObject Text;
    TextMeshProUGUI gasTankText;

    private void Start()
    {
        key = 0;
        gasTankText = Text.GetComponent<TextMeshProUGUI>();
        gasTankText.text = $"Gas tanks: {key}/5";
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Key"))
        {
            if (key <= 3)
            {
                Debug.Log("KEY COLLECTED");
                key++;
                gasTankText.text = $"Gas tanks: {key}/5";
                Destroy(collision.gameObject);
            }
            else if(key >= 4)
            {
                gasTankText.text = $"Head to helicopter!";
            }
        }
    }
}
