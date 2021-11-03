using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPVisual : MonoBehaviour
{
    [SerializeField] private PlayerHP _playerHP;
    [SerializeField] private Slider _sliderHP;
    [SerializeField] private Text _textHP;
    private void Awake()
    {
        _sliderHP.maxValue = _playerHP.HP;
        _sliderHP.value = _sliderHP.maxValue;
        _textHP.text = _sliderHP.value.ToString()+"/"+ _sliderHP.maxValue;
    }
    private void OnEnable()
    {
        _playerHP.SetedHp += OnSetedHP;
        _sliderHP.onValueChanged.AddListener(OnValueChanged);
    }
    private void OnSetedHP(int score)
    {
        _sliderHP.value = score;
    }
    private void OnValueChanged(float value)
    {
        string newText = _textHP.text;
        newText = newText.Substring(newText.IndexOf('/'));
        _textHP.text = value.ToString()+newText;
    }
    private void OnDisable()
    {
        _playerHP.SetedHp -= OnSetedHP;
        _sliderHP.onValueChanged.RemoveListener(OnValueChanged);
    }
}
