using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class BulletController : MonoBehaviour
{
    [SerializeField]
    private float deactivationTime;

    [SerializeField]
    private Image _image;

    private BasicEnemyController _currentlyHitEnemy;
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

            _currentlyHitEnemy = collider.gameObject.GetComponent<BasicEnemyController>();
            GameManager.Singleton.PlayerStats.Score += _currentlyHitEnemy.Type.Point;

            GameManager.Singleton.LevelManger.CurrentLevelData.NoteEnemyKilled(_currentlyHitEnemy.Type);

            if(GameManager.Singleton.LevelManger.CurrentLevelData.CheckForLevelCleared())
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

    public void SetBulletOwner(BulletOwnerEnum owner)
    {
        _bulletOwner = owner;
        RecolorBullet();
    }

    public void RecolorBullet()
    {
        if(_bulletOwner == BulletOwnerEnum.Player)
        {
            _image.color = Color.green;
        }
        else
        {
            _image.color = Color.red;
        }
    }
}
