using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public float timer;
    public bool timeStarted = false;
    public string Countdown;
    public TextMeshProUGUI timerTxt;
    public GameObject LoseHUD;
    // Start is called before the first frame update
    void Start()
    {
        //timeStarted = true;
        LoseHUD.SetActive(false);
        Time.timeScale = 1f;
    }

    public void OnGUI()
    {
        int minutes = Mathf.FloorToInt(timer / 60F);
        int seconds = Mathf.FloorToInt(timer - minutes * 60);
        string niceTime = string.Format("{00}", seconds);
        Countdown = niceTime;
    }

    public void GameTime()
    {
        timerTxt.text = Countdown.ToString();
        if (timeStarted == true)
        {
            timer -= Time.deltaTime;
        }
    }

    public void Losing()
    {
        if (timer <= 0f)
        {
            Time.timeScale = 0;
            LoseHUD.SetActive(true);
            timer = 0f;
            Time.timeScale = 0f;
            //Cursor.lockState = CursorLockMode.None;
        }
    }

    // Update is called once per frame
    void Update()
    {
        GameTime();
        Losing();
    }
}
