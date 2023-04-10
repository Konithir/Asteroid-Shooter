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
    private float _initialEnemySpawnTime;

    [Range(0, 100)]
    [SerializeField]
    private float _intervalEnemySpawnTime;

    [SerializeField]
    private List<EnemyTypeAmountWrapper> _enemiesTypes;

    public string LevelName
    {
        get { return _levelName; }
    }

    public float InitialEnemySpawnTime
    {
        get { return _initialEnemySpawnTime; }
    }

    public float IntervalEnemySpawnTime
    {
        get { return _intervalEnemySpawnTime; }
    }

    public List<EnemyTypeAmountWrapper> EnemiesTypes
    {
        get { return _enemiesTypes; }
    }

    public void NoteEnemyDeployment(EnemyType type)
    {
        for(int i = 0; i < _enemiesTypes.Count; i++)
        {
            if(type == _enemiesTypes[i].EnemyType)
            {
                _enemiesTypes[i].CurrentlyDeployedAmount++;
                return;
            }
        }
    }

    public void NoteEnemyEndOfDeployment(EnemyType type)
    {
        for (int i = 0; i < _enemiesTypes.Count; i++)
        {
            if (type == _enemiesTypes[i].EnemyType)
            {
                _enemiesTypes[i].CurrentlyDeployedAmount--;
                return;
            }
        }
    }

    public void NoteEnemyKilled(EnemyType type)
    {
        for (int i = 0; i < _enemiesTypes.Count; i++)
        {
            if (type == _enemiesTypes[i].EnemyType)
            {
                _enemiesTypes[i].CurrentlyDeployedAmount--;
                _enemiesTypes[i].CurrentlyKilledAmount++;
                return;
            }
        }
    }

    public bool CheckForLevelCleared()
    {
        for (int i = 0; i < _enemiesTypes.Count; i++)
        {
            if (_enemiesTypes[i].EnemyAmount > _enemiesTypes[i].CurrentlyKilledAmount)
            {
                return false;
            }
        }

        return true;
    }

    public void Reset()
    {
        for (int i = 0; i < _enemiesTypes.Count; i++)
        {
            _enemiesTypes[i].Reset();
        }
    }
}