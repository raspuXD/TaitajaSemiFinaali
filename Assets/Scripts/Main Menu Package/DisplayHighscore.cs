using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayHighscore : MonoBehaviour
{
    public bool usesPoints, usesStars, usesLongestTime, usesShortestTime;
    public TMP_Text scoreText;
    public GameObject[] stars;

    private void Start()
    {
        if(usesPoints)
        {
            int points = PlayerPrefs.GetInt("HighestPoints", 0);
            scoreText.text = points.ToString() + " points";
        }
        if (usesStars)
        {
            int starAmount = PlayerPrefs.GetInt("HighestStars", 0); // Assuming stars are stored under "HighestStars"
            scoreText.text = ""; // Clear the text since stars will be displayed graphically

            // Activate stars based on the amount
            for (int i = 0; i < stars.Length; i++)
            {
                if (stars[i] != null)
                    stars[i].SetActive(i < starAmount);
            }
        }
        if (usesLongestTime)
        {
            float time = PlayerPrefs.GetFloat("HighestTime", 0);
            if (time >= 60)
            {
                int minutes = Mathf.FloorToInt(time / 60);
                int seconds = Mathf.FloorToInt(time % 60);
                scoreText.text = $"{minutes}m {seconds}s";
            }
            else
            {
                scoreText.text = $"{Mathf.FloorToInt(time)} seconds";
            }
        }
        if (usesShortestTime)
        {
            float time = PlayerPrefs.GetFloat("SmallestTime", 0);
            if (time >= 60)
            {
                int minutes = Mathf.FloorToInt(time / 60);
                int seconds = Mathf.FloorToInt(time % 60);
                scoreText.text = $"{minutes}m {seconds}s";
            }
            else
            {
                scoreText.text = $"{Mathf.FloorToInt(time)} seconds";
            }
        }

    }
}
