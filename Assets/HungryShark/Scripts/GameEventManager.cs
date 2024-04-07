using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEventManager : MonoBehaviour
{
    private Shark playerShark;

    private float _timeToEscapeInSeconds = 50;
    private int _score = 0;
    private int _health = 100;
    [SerializeField] private TMP_Text _scoreText, _healthText, _timeRemainingText;
    [SerializeField] private GameObject _loseScreen;

    private void Start()
    {
        playerShark = FindObjectOfType<Shark>();
        UpdateScore();
        UpdateHealth();
    }

    private void FixedUpdate()
    {
        UpdateTime();
    }

    public void AddToScore(int scoreToAdd)
    {
        _score = (int)Mathf.Clamp(_score + scoreToAdd, 0, Mathf.Infinity);
        UpdateScore();
    }

    public void AddToHealth(int healthToAdd)
    {
        _health += healthToAdd;
        _health = (int)Mathf.Clamp(_health + healthToAdd, 0, 120);

        if (_health <= 0)
        {
            TriggerLose();
        }

        UpdateHealth();
    }

    private void UpdateScore()
    {
        _scoreText.text = $"Score: {_score}";
    }

    private void UpdateHealth()
    {
        _healthText.text = $"Health: {_health}";
    }

    private void UpdateTime() 
    {
        _timeToEscapeInSeconds -= Time.deltaTime;
        _timeRemainingText.text = $"Time left to escape maze: {System.Math.Round(_timeToEscapeInSeconds, 2)}";
        if (_timeToEscapeInSeconds <= 0) 
        {
            TriggerLose();
        }
    }

    private void TriggerLose()
    {
        playerShark.enabled = false;
        _loseScreen.SetActive(true);
        enabled = false;
    }

    public void RestartCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
