using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Tutorial : MonoBehaviour
{
    [SerializeField] GameObject Text;
    TextMeshProUGUI tutorial;

    void Awake()
    {
        tutorial = Text.GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        this.gameObject.GetComponent<Outline>().enabled = true;
        switch (this.gameObject.name)
        {
            case "Sign 0":
                tutorial.text = "Press WASD to move around";
                Text.SetActive(true);
                break;

            case "Sign 1":
                tutorial.text = "Press LEFT CTRL to crouch";
                Text.SetActive(true);
                break;
            case "Sign 2":
                tutorial.text = "Press SPACE to jump";
                Text.SetActive(true);
                break;
            case "Sign 3":
                tutorial.text = "Hold SPACE on walls highlighted in orange to climb";
                Text.SetActive(true);
                break;
        }
    }

    private void OnMouseExit()
    {
        this.gameObject.GetComponent<Outline>().enabled = false;
        Text.SetActive(false);
    }
}
