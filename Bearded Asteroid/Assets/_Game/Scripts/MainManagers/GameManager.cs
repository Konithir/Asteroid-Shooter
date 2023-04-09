using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private PlayerStats _playerStats;

    [SerializeField]
    private LevelManager _levelManager;

    private static GameManager _singleton;

    public UnityEvent OnPointChange;

    public UnityEvent OnDamageReceived;

    public static GameManager Singleton
    {
        get { return _singleton; }
    }

    public LevelManager LevelManger
    {
        get { return _levelManager; }
    }

    public PlayerStats PlayerStats
    {
        get { return _playerStats; }
    }

    private void Awake()
    {
        _singleton = this;

        Reset();
    }

    private void Reset()
    {
        _playerStats.Reset();
    }
}
