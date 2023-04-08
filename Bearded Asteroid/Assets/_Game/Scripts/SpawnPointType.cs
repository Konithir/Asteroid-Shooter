using UnityEngine;

[CreateAssetMenu(menuName = "Bearded_Asteroid/SpawnPoint/SpawnPointType")]
public class SpawnPointType : ScriptableObject
{
    [SerializeField]
    private SpawnPointEnum _spawnPointEnum;
}
