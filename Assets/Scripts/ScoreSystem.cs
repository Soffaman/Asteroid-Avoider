using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] TMP_Text _scoreText;
    [SerializeField] private float _scoreMultiplier = 5f;

    private bool _shouldCount = true;
    private float _score = 0f;


    private void Update()
    {
        if (!_shouldCount)
        {
            return;
        }
        _score += Time.deltaTime * _scoreMultiplier;

        _scoreText.text = Mathf.FloorToInt(_score).ToString();
    }

    public int EndTimer()
    {
        _shouldCount = false;
        _scoreText.text = string.Empty;

        return Mathf.FloorToInt(_score);
    }
}
