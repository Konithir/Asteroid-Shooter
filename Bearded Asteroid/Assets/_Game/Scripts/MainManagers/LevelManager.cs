using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private List<LevelData> _levelDatas;

    private LevelData _currentLevelData;

    public UnityEvent OnNewLevelStarted;

    public LevelData CurrentLevelData
    {
        get { return _currentLevelData; }
    }

    private void Awake()
    {
        SetCurrentLeveData();
        ResetLevelData();
    }

    private void Start()
    {
        StartCurrentLevel();
    }

    private void StartCurrentLevel()
    {
        OnNewLevelStarted?.Invoke();
    }

    private void SetCurrentLeveData()
    {
        _currentLevelData = _levelDatas[0];
    }

    private void ResetLevelData()
    {
        for(int i = 0; i < _levelDatas.Count; i++)
        {
            _levelDatas[i].Reset();
        }
    }

    public void ProgressNextLevel()
    {
        _currentLevelData = _levelDatas[_levelDatas.IndexOf(_currentLevelData) +1];
        GameManager.Singleton.PlayerStats.LevelAchievedName = _currentLevelData.LevelName;
        OnNewLevelStarted?.Invoke();
    }
}
