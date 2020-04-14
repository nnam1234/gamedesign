using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public int lives = 20;
    public int money = 10;
    public int wave = 0;

    public Text moneyText;
    public Text livesText;
    public Text waveText;

    public Text FireNumText;
    public Text WaterNumText;
    public Text EarthNumText;

    public void loseLife(int l = 1)
    {
        lives -= l;
        if (lives <= 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        Debug.Log("Game OVER");

    }

    private void Update()
    {

        GameObject[] FireNum = GameObject.FindGameObjectsWithTag("Fire");
        int FireCount = FireNum.Length;
        GameObject[] WaterNum = GameObject.FindGameObjectsWithTag("Water");
        int WaterCount = WaterNum.Length;
        GameObject[] EarthNum = GameObject.FindGameObjectsWithTag("Earth");
        int EarthCount = EarthNum.Length;

        FireNumText.text = "                          " + FireCount.ToString();
        WaterNumText.text = "                          " + WaterCount.ToString();
        EarthNumText.text = "                          " + EarthCount.ToString();




        //Debug.Log(thingyCount);

    }

}
