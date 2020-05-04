using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthTracker : MonoBehaviour
{
    float health = 100;

    [SerializeField] GameObject Text;
    TextMeshProUGUI healthText;
    void Start()
    {
        healthText = Text.GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            health--;
            healthText.text = $"Health: {health}";
        }
    }

}
