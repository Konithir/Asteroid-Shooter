using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private PlayerStats _playerStats;

    [SerializeField]
    private LevelManager _levelManager;

    [SerializeField]
    private PlayerShipController _playerShipController;

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

    public PlayerShipController PlayerShipController
    {
        get { return _playerShipController; }
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
