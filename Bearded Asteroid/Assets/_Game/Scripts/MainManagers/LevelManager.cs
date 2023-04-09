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

    public void ProgressNextLevel()
    {
        _currentLevelData = _levelDatas[_levelDatas.IndexOf(_currentLevelData) +1];
        OnNewLevelStarted?.Invoke();
    }
}
