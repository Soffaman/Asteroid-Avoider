using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverHandler : MonoBehaviour
{
    [SerializeField] private TMP_Text _gameOverText;
    [SerializeField] private ScoreSystem _scoreSystem;
    [SerializeField] private GameObject _gameOverDisplay;
    [SerializeField] private AsteroidSpawner _asteroidSpawner; 
    public void EndGame()
    {
        int finalScore = _scoreSystem.EndTimer();
        _gameOverText.text = $"Your Score: {finalScore}";

        _asteroidSpawner.enabled = false;
        _gameOverDisplay.gameObject.SetActive(true);
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene(1);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
