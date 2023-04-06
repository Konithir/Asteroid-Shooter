using UnityEngine;

public class SpawnPointController : MonoBehaviour
{
    [SerializeField]
    private SpawnPointType _spawnPointType;

    public SpawnPointType SpawnPointType
    {
        get { return _spawnPointType; }
    }
}
