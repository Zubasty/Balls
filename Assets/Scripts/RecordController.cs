using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordController : MonoBehaviour
{
    public const string RECORD_KEY = "RECORD";
    [SerializeField] private PlayerHP _playerHP;
    [SerializeField] private PlayerScore _playerScore;
    public event Action<int> SetRecord;
    private void OnEnable()
    {
        _playerHP.LosePlayer += OnLosePlayer;
    }
    private void OnLosePlayer()
    {
        if (PlayerPrefs.HasKey(RECORD_KEY))
        {
            if (_playerScore.Score > PlayerPrefs.GetInt(RECORD_KEY))
            {
                SaveRecord();
            }
        }
        else
        {
            SaveRecord();
        }
    }
    private void SaveRecord()
    {
        PlayerPrefs.SetInt(RECORD_KEY, _playerScore.Score);
        PlayerPrefs.Save();
        SetRecord?.Invoke(_playerScore.Score);
    }
    private void OnDisable()
    {
        _playerHP.LosePlayer -= OnLosePlayer;
    }
}
