using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class CountDown : MonoBehaviour
{
    public int timeLeft = 5;
    public TextMeshProUGUI countdown;
    private GameManagerX gameManagerX;
    // Start is called before the first frame update
    void Start()
    {
        gameManagerX = GameObject.Find("Game Manager").GetComponent<GameManagerX>();
    }
    public void StartCountdown()
    {
        StartCoroutine("LoseTime");
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        countdown.text = ("" + timeLeft);
    }

    IEnumerator LoseTime()
    {
        while (timeLeft>0)
        {
            yield return new WaitForSeconds(1);
            timeLeft--;
            if(timeLeft==0){ gameManagerX.GameOver();}
        }
    }
}
