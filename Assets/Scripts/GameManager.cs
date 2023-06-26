using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Text _playerScore;
    [SerializeField] private Text _enemyScore;
    private int pScore;
    private int eScore;

    private void Awake()
    {
        pScore = 0;
        eScore = 0;
    }
    private void Update()
    {
        SetScore();
    }
    public void Win()
    {
        SoundManager.instance.WinSound();
        pScore += 1;
    }
    public void Lose()
    {
        SoundManager.instance.LoseSound();
        eScore += 1;
    }
    public void SetScore()
    {
        _playerScore.text = pScore.ToString();
        _enemyScore.text = eScore.ToString();
    }
}
