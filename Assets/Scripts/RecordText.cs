using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecordText : MonoBehaviour
{
    private const string START_TEXT = "Рекорд: ";
    [SerializeField] private Text _text;
    [SerializeField] private RecordController _recordController;
    private void Awake()
    {
        if (PlayerPrefs.HasKey(RecordController.RECORD_KEY))
        {
            _text.text = START_TEXT + PlayerPrefs.GetInt(RecordController.RECORD_KEY);
        }
        else
        {
            _text.text = START_TEXT + 0;
        }
    }
    private void OnEnable()
    {
        _recordController.SetRecord += OnSetRecord;
    }
    private void OnSetRecord(int score)
    {
        _text.text = START_TEXT + score.ToString();
    }
    private void OnDisable()
    {
        _recordController.SetRecord -= OnSetRecord;
    }
}
