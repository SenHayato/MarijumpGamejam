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
        timeStarted = true;
        LoseHUD.SetActive(false);
        Time.timeScale = 1f;
    }

    public void OnGUI()
    {
        int minutes = Mathf.FloorToInt(timer / 60F);
        int seconds = Mathf.FloorToInt(timer - minutes * 60);
        string niceTime = string.Format("{0:0}:{1:00}", minutes, seconds);
        Countdown = niceTime;
    }

    public void GameTime()
    {
        timerTxt.text = Countdown.ToString();
        if (timeStarted == true)
        {
            timer -= Time.deltaTime;
            //LightRot = transform.Rotate(1f * Time.deltaTime, 0f, 0f);
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
