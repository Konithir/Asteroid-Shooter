using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/SpawnPoint/SpawnPointType")]
public class SpawnPointType : ScriptableObject
{
    [SerializeField]
    private SpawnPointEnum _spawnPointEnum;
}
