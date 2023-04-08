using DG.Tweening;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField]
    private float deactivationTime;

    private AsteroidController _currentlyHitAsteroid;

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
        if(collider.CompareTag("Asteroid"))
        {
            collider.gameObject.SetActive(false);
            gameObject.SetActive(false);

            _currentlyHitAsteroid = collider.gameObject.GetComponent<AsteroidController>();
            GameManager.Singleton.PlayerStats.Score += _currentlyHitAsteroid.Type.Point;

            GameManager.Singleton.OnPointChange?.Invoke();
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
}
