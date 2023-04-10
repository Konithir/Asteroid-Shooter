using DG.Tweening;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField]
    private float deactivationTime;

    private BasicEnemyController _currentlyHitAsteroid;
    private BulletOwnerEnum _bulletOwner;

    public BulletOwnerEnum BulletOwner
    {
        set { _bulletOwner = value;  }
    }

    private void OnEnable()
    {
        Invoke(nameof(Deactivation), deactivationTime);
    }

    private void OnDisable()
    {
        StopTweens();
        CancelDeactivationInvoke();
    }

    private void Deactivation()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        HandleColisions(other);
    }

    private void HandleColisions(Collider collider)
    {
        if(_bulletOwner == BulletOwnerEnum.Player && collider.CompareTag("Asteroid"))
        {
            collider.gameObject.SetActive(false);
            gameObject.SetActive(false);

            _currentlyHitAsteroid = collider.gameObject.GetComponent<BasicEnemyController>();
            GameManager.Singleton.PlayerStats.Score += _currentlyHitAsteroid.Type.Point;

            GameManager.Singleton.LevelManger.CurrentLevelData.CurrentEnemiesCountKilled++;

            if(GameManager.Singleton.LevelManger.CurrentLevelData.CurrentEnemiesCountKilled >= GameManager.Singleton.LevelManger.CurrentLevelData.EnemiesCount)
            {
                GameManager.Singleton.LevelManger.ProgressNextLevel();
            }

            GameManager.Singleton.OnPointChange?.Invoke();
        }
        else if(_bulletOwner == BulletOwnerEnum.Enemy && collider.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            GameManager.Singleton.PlayerShipController.HandleDeath();
        }

    }

    private void StopTweens()
    {
        DOTween.Kill(transform);
    }

    private void CancelDeactivationInvoke()
    {
        CancelInvoke();
    }

    private void SetBulletOwner(BulletOwnerEnum owner)
    {
        _bulletOwner = owner;
    }
}
