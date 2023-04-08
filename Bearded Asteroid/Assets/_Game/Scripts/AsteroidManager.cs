using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoBehaviour
{
    [Range(0,float.MaxValue)]
    [SerializeField]
    private float _asteroidSpeedMinValue;

    [Range(0, float.MaxValue)]
    [SerializeField]
    private float _asteroidSpeedMaxValue;

    [Range(0, 100)]
    [SerializeField]
    private int _maxScreenAsteroidCount;

    [Range(0, 500)]
    [SerializeField]
    private float _initialAstroidSpawnTime;

    [Range(0, 100)]
    [SerializeField]
    private float _intervalAsteroidSpawnTime;

    [SerializeField]
    private List<AsteroidController> _asteroidList;

    [SerializeField]
    private List<AsteroidType> _asteroidTypes;

    [SerializeField]
    private List<SpawnPointController> _spawnPoints;

    private AsteroidController _currentAsteroid;
    private SpawnPointController _currentSpawnPoint_start;
    private SpawnPointController _currentSpawnPoint_end;
    private int _tempAsteroidInt;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnAsteroid), _initialAstroidSpawnTime, _intervalAsteroidSpawnTime);
    }

    private void SpawnAsteroid()
    {
        if (GetActiveAsteroidCount() >=_maxScreenAsteroidCount)
            return;

        _currentAsteroid = FindFirstInactive(_asteroidList);
        _currentAsteroid.Type = GetRandomAsteroidType();

        SetTwoSpawnPointsFromDifferentTypes();

        _currentAsteroid.transform.position = _currentSpawnPoint_start.transform.position;
        _currentAsteroid.HandleMovement(_currentSpawnPoint_end.transform.position, _asteroidSpeedMinValue, _asteroidSpeedMaxValue);

        _currentAsteroid.gameObject.SetActive(true);

    }

    private AsteroidController FindFirstInactive(List<AsteroidController> list)
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

    private int GetActiveAsteroidCount()
    {
        _tempAsteroidInt = 0;

        for(int i = 0; i < _asteroidList.Count; i++)
        {
            if(_asteroidList[i].gameObject.activeInHierarchy)
            {
                _tempAsteroidInt++;
            }
        }

        return _tempAsteroidInt;
    }

    private AsteroidType GetRandomAsteroidType()
    {
        return _asteroidTypes[Random.Range(0, _asteroidTypes.Count)];
    }

   
}
