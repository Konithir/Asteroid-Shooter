using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Bearded_Asteroid/Level/LevelData")]
public class LevelData : ScriptableObject
{
    [SerializeField]
    private string _levelName;

    [Range(0, 100)]
    [SerializeField]
    private float _initialAstroidSpawnTime;

    [Range(0, 100)]
    [SerializeField]
    private float _intervalAsteroidSpawnTime;

    [SerializeField]
    private int _enemiesCountToKill;

    [SerializeField]
    private List<EnemyType> _enemiesTypes;

    private int _currentEnemiesCountKilled;

    public string LevelName
    {
        get { return _levelName; }
    }

    public float InitialAstroidSpawnTime
    {
        get { return _initialAstroidSpawnTime; }
    }

    public float IntervalAsteroidSpawnTime
    {
        get { return _intervalAsteroidSpawnTime; }
    }

    public int EnemiesCount
    {
        get { return _enemiesCountToKill; }
    }

    public int CurrentEnemiesCountKilled
    {
        get { return _currentEnemiesCountKilled; }
        set { _currentEnemiesCountKilled = value; }
    }

    public List<EnemyType> EnemiesTypes
    {
        get { return _enemiesTypes; }
    }

    public void Reset()
    {
        _currentEnemiesCountKilled = 0;
    }
}