using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Fish : MonoBehaviour, IFish
{
    protected Shark _playerShark;
    private int _healthToGive;
    private int _scoreWhenEaten;
    
    [SerializeField] private UnityEvent _onEaten;
    public UnityEvent OnEaten => _onEaten;

    protected int HealthToGive { get => _healthToGive; set => _healthToGive = value; }
    protected int ScoreWhenEaten { get => _scoreWhenEaten; set => _scoreWhenEaten = value; }

    public abstract void TriggerEatenEffect();
    public abstract void Init();

    private void Start()
    {
        _playerShark = FindObjectOfType<Shark>();
        GameEventManager gameEventManager = FindObjectOfType<GameEventManager>();
        _onEaten.AddListener(() => gameEventManager.AddToHealth(_healthToGive));
        _onEaten.AddListener(() => gameEventManager.AddToScore(_scoreWhenEaten));
        _onEaten.AddListener(TriggerEatenEffect);
        Init();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Shark>())
        {
            _onEaten?.Invoke();
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        _onEaten.RemoveAllListeners();
    }
}
