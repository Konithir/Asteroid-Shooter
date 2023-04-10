using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipController : MonoBehaviour
{
    [Tooltip("Player Speed Per Delta Time")]
    [SerializeField]
    private float _speed;

    [SerializeField]
    private Animation _deathEffect;

    [SerializeField]
    private GameObject _graphic;

    [SerializeField]
    private float _deathWaitTime;

    [SerializeField]
    private Vector3 _teleportPoint;

    [SerializeField]
    private SphereCollider _collider;

    [SerializeField]
    private LoadSceneController _loadSceneController;

    private WaitForSeconds _waitForSeconds;
    private Vector3 _movementVector;
    private Vector3 _mousePositionDifference;
    private float _rotationZ;

    private void Start()
    {
        Init();
    }

    private void Update()
    {
        if (!_graphic.activeInHierarchy)
            return;

        PrepareMovementVector();
        RotateToCursor();
        HandleFiring();
    }

    private void LateUpdate()
    {
        if (!_graphic.activeInHierarchy)
            return;

        CompleteMovement();
    }

    private void OnDisable()
    {
        StopTweens();
    }

    private void PrepareMovementVector()
    {
        _movementVector = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            _movementVector.y++;
        }

        if (Input.GetKey(KeyCode.S))
        {
            _movementVector.y--;
        }

        if (Input.GetKey(KeyCode.A))
        {
            _movementVector.x--;
        }

        if (Input.GetKey(KeyCode.D))
        {
            _movementVector.x++;
        }
    }

    private void CompleteMovement()
    {
        transform.DOMove(transform.position + (_movementVector * _speed * Time.deltaTime), Time.deltaTime);
    }

    private void RotateToCursor()
    {
        _mousePositionDifference = transform.position - Input.mousePosition;
        _rotationZ = Mathf.Atan2(_mousePositionDifference.y, _mousePositionDifference.x) * Mathf.Rad2Deg;
        transform.DORotateQuaternion(Quaternion.Euler(0.0f, 0.0f, _rotationZ), Time.deltaTime);
    }

    private void HandleFiring()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameManager.Singleton.BulletManager.ShootBullet(gameObject, BulletOwnerEnum.Player);
        }
    }

    private void StopTweens()
    {
        DOTween.Kill(transform);
    }

    private void Init()
    {
        _waitForSeconds = new WaitForSeconds(_deathWaitTime);
    }

    public void PlayDeathEffect()
    {
        _deathEffect.Play();
    }

    public void DisableGraphic()
    {
        _graphic.SetActive(false);
        SwitchCollider(false);
    }

    public void EnableGraphic()
    {
        _graphic.SetActive(true);
        SwitchCollider(true);
    }

    public void RespawnShip()
    {
        StartCoroutine(RespawnShipCoroutine());
    }

    private IEnumerator RespawnShipCoroutine()
    {
        yield return _waitForSeconds;

        EnableGraphic();
        TeleportShipToPoint();
    }

    public void TeleportShipToPoint()
    {
        gameObject.SetActive(false);
        transform.localPosition = _teleportPoint;
        gameObject.SetActive(true);
    }

    public void TeleportShipToPoint(Vector3 point)
    {
        gameObject.SetActive(false);
        transform.localPosition = point;
        gameObject.SetActive(true);
    }

    private void SwitchCollider(bool value)
    {
        _collider.enabled = value;
    }

    public void HandleDeath()
    {
        PlayDeathEffect();
        DisableGraphic();

        RespawnShip();

        GameManager.Singleton.PlayerStats.Lives--;
        GameManager.Singleton.OnDamageReceived?.Invoke();


        if (GameManager.Singleton.PlayerStats.Lives <= 0)
        {
            _loadSceneController.LoadScene();
        }
    }
}
