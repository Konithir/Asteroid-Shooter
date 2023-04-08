using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipController : MonoBehaviour
{

    [Tooltip("Player Speed Per Delta Time")]
    [SerializeField]
    private float _speed;

    [Tooltip("Bullet Speed Per Bullet LifeTime")]
    [SerializeField]
    private float _bulletSpeed;

    [Tooltip("Bullet Initial Offset So Bullet doesn't Appear On Ship")]
    [SerializeField]
    private float _bulletInitialOffset;

    [SerializeField]
    private List<BulletController> _bulletList;

    private Vector3 _movementVector;
    private Vector3 _mousePositionDifference;
    private float _rotationZ;
    private BulletController _currentBullet;

    private const float BULLET_TWEEN_TIME = 2;

    private void Update()
    {
        PrepareMovementVector();
        RotateToCursor();
        HandleFiring();
    }

    private void LateUpdate()
    {
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
        transform.DOMove(transform.position + (_movementVector * _speed), Time.deltaTime);
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
            ActivateBullet();
        }
    }

    private void ActivateBullet()
    {
        _currentBullet = FindFirstInactive(_bulletList);

        _currentBullet.transform.position = transform.position - (transform.right * _bulletInitialOffset);
        _currentBullet.transform.DOMove(transform.position - (transform.right * _bulletSpeed), BULLET_TWEEN_TIME).SetEase(Ease.Linear);

        _currentBullet.gameObject.SetActive(true);
    }

    private BulletController FindFirstInactive(List<BulletController> list)
    {
        for(int i = 0; i < list.Count; i++)
        {
            if(!list[i].gameObject.activeInHierarchy)
            {
                return list[i];
            }
        }

        return null;
    }

    private void StopTweens()
    {
        DOTween.Kill(transform);
    }
}
