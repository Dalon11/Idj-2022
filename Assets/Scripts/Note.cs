using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Note : MonoBehaviour
{
    [SerializeField] GameObject canvas;
    [SerializeField] Text textUI;
    [SerializeField] string text;
    private void OnEnable()
    {
        if (!textUI) return;
        textUI.text = text;
    }
   
    void OnTriggerEnter2D(Collider2D collision)
    {
        canvas.SetActive(true);
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        canvas.SetActive(false);
    }
}
