using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCount : MonoBehaviour
{
    int _score = 0;
    [SerializeField] Text _scoreText = null;
    public static ScoreCount instance;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        _scoreText.text = " SCORE : " + _score.ToString("D4");
    }

    public void KillCountPlus(int x)
    {
        _score += x;
        _scoreText.text = " SCORE : " + _score.ToString("D4");
    }
}
