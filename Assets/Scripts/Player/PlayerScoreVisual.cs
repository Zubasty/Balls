using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScoreVisual : MonoBehaviour
{
    [SerializeField] private PlayerScore _playerScore;
    [SerializeField] private Text _text;
    private void OnEnable()
    {
        _playerScore.SetedScore += OnSetedScore;
    }
    private void OnSetedScore(int score)
    {
        _text.text = score.ToString();
    }
    private void OnDisable()
    {
        _playerScore.SetedScore -= OnSetedScore;
    }
}
