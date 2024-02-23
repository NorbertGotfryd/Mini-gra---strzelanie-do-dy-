using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    public static UI instance;

    [SerializeField] private TextMeshProUGUI scoreText;

    public int scorePoints;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        ScorePoints();
    }

    public void ScorePoints()
    {
        scoreText.text = scorePoints.ToString();
    }

}
