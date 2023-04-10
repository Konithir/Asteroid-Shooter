using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField]
    private List<BasicEnemyController> _blankEnemyList;

    [SerializeField]
    private List<ShootingEnemyController> _blankShootingEnemyList;

    [SerializeField]
    private List<SpawnPointController> _spawnPoints;

    private EnemyType _currentEnemyType;
    private BasicEnemyController _currentEnemy;
    private SpawnPointController _currentSpawnPoint_start;
    private SpawnPointController _currentSpawnPoint_end;
    private int _tempAsteroidInt;

    private void Awake()
    {
        SubscribeToEvents();
    }

    private void SubscribeToEvents()
    {
        GameManager.Singleton.LevelManger.OnNewLevelStarted.AddListener(NewLevelStart);
    }

    private void NewLevelStart()
    {
        ClearEnemies();
        StartSpawningAsteroids();
    }

    private void StartSpawningAsteroids()
    {
        InvokeRepeating(nameof(SpawnAsteroid),
           GameManager.Singleton.LevelManger.CurrentLevelData.InitialAstroidSpawnTime,
           GameManager.Singleton.LevelManger.CurrentLevelData.IntervalAsteroidSpawnTime);
    }

    private void SpawnAsteroid()
    {
        _currentEnemyType = GetRandomEnemyType(GameManager.Singleton.LevelManger.CurrentLevelData);

        if(_currentEnemyType.ShootsBullets)
            _currentEnemy = FindFirstInactive(_blankShootingEnemyList);
        else
            _currentEnemy = FindFirstInactive(_blankEnemyList);

        _currentEnemy.Type = _currentEnemyType;

        SetTwoSpawnPointsFromDifferentTypes();

        _currentEnemy.transform.position = _currentSpawnPoint_start.transform.position;
        _currentEnemy.HandleMovement(_currentSpawnPoint_end.transform.position, _currentEnemy.Type);

        _currentEnemy.gameObject.SetActive(true);

    }

    private BasicEnemyController FindFirstInactive(List<BasicEnemyController> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (!list[i].gameObject.activeInHierarchy)
            {
                return list[i];
            }
        }

        return null;
    }

    private BasicEnemyController FindFirstInactive(List<ShootingEnemyController> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (!list[i].gameObject.activeInHierarchy)
            {
                return list[i];
            }
        }

        return null;
    }

    private SpawnPointController GetRandomSpawnPoint()
    {
        return _spawnPoints[Random.Range(0, _spawnPoints.Count)];
    }

    private void SetTwoSpawnPointsFromDifferentTypes()
    {
        _currentSpawnPoint_start = GetRandomSpawnPoint();

        do
        {
            _currentSpawnPoint_end = GetRandomSpawnPoint();
        }
        while (_currentSpawnPoint_start.SpawnPointType == _currentSpawnPoint_end.SpawnPointType);
    }

    private EnemyType GetRandomEnemyType(LevelData data)
    {
        return data.EnemiesTypes[Random.Range(0, data.EnemiesTypes.Count)];
    }

    private void ClearEnemies()
    {
        CancelInvoke();

        for(int i = 0; i < _blankEnemyList.Count; i++)
        {
            _blankEnemyList[i].gameObject.SetActive(false);
        }

        for (int i = 0; i < _blankShootingEnemyList.Count; i++)
        {
            _blankShootingEnemyList[i].gameObject.SetActive(false);
        }
    }

   
}
