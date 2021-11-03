using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    [SerializeField] private PlayerHP _playerHP;
    [SerializeField] private PlayerScore _playerScore;
    [SerializeField] private GameObject _loseMenu;
    [SerializeField] private Text _textNowScore;
    private void OnEnable()
    {
        _playerHP.LosePlayer += OnLosePlayer;
    }
    private void OnLosePlayer()
    {
        _loseMenu.SetActive(true);
        _textNowScore.text = "Ты набрал: " + _playerScore.Score.ToString();
    }
    private void OnDisable()
    {
        _playerHP.LosePlayer -= OnLosePlayer;
    }
}
