using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MouseEnter : MonoBehaviour
{
    private void OnMouseEnter()
    {
        this.gameObject.GetComponent<Outline>().enabled = true;
    }

    private void OnMouseOver()
    {
        this.gameObject.GetComponent<Outline>().enabled = true;

    }

    private void OnMouseExit()
    {
        this.gameObject.GetComponent<Outline>().enabled = false;
    }
}
