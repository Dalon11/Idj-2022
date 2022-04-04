using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    [SerializeField] Text textKey;
    [Space]
    [SerializeField] GameObject textPause;

    bool isPause = false;
    public bool IsPause
    {
        get => isPause;
        set 
        {
            if (value == true)
                PauseOn();
            else
                PauseOff();
            isPause = value; 
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            IsPause = !IsPause;
    }
    public void TextKeyUpdate(int currentKey)
    {
        textKey.text = currentKey.ToString();
    }
    void PauseOn()
    {
        Time.timeScale = 0;
        textPause.SetActive(true);
    }
    void PauseOff()
    {
        Time.timeScale = 1;
        textPause.SetActive(false);
    }
    public void ExitGame()=>Application.Quit();
    public void RestartGame()
    {
        PauseOff();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
}
