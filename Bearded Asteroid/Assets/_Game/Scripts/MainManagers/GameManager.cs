using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private PlayerStats _playerStats;

    private static GameManager _singleton;

    public UnityEvent OnPointChange;

    public UnityEvent OnDamageReceived;

    public static GameManager Singleton
    {
        get { return _singleton; }
    }

    public PlayerStats PlayerStats
    {
        get { return _playerStats; }
    }

    private void Awake()
    {
        _singleton = this;
    }
}
