using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(menuName = "Bearded_Asteroid/Enemies/EnemyTypeAmountWrapper")]
public class EnemyTypeAmountWrapper : ScriptableObject
{
    [SerializeField]
    private int _enemyAmount;

    [SerializeField]
    private EnemyType _enemyType;

    private int _currentlyKilledAmount;
    private int _currentlyDeployedAmount;

    public int EnemyAmount
    {
        get { return _enemyAmount; }
    }

    public EnemyType EnemyType
    {
        get { return _enemyType; }
    }

    public int CurrentlyKilledAmount
    {
        get { return _currentlyKilledAmount; }
        set { _currentlyKilledAmount = value; }
    }

    public int CurrentlyDeployedAmount
    {
        get { return _currentlyDeployedAmount; }
        set { _currentlyDeployedAmount = value; }
    }

    public void Reset()
    {
        _currentlyKilledAmount = 0;
        _currentlyDeployedAmount = 0;
    }
}
