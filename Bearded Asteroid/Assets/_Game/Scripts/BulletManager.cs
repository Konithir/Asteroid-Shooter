using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    [Tooltip("Bullet Speed Per Bullet LifeTime")]
    [SerializeField]
    private float _bulletSpeed;

    [Tooltip("Bullet Initial Offset So Bullet doesn't Appear On Ship")]
    [SerializeField]
    private float _bulletInitialOffset;

    [SerializeField]
    private List<BulletController> _bulletList;

    private BulletController _currentBullet;

    private const float BULLET_TWEEN_TIME = 2;

    private BulletController FindFirstInactive(List<BulletController> list)
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

    public void ShootBullet(GameObject shootingObject, BulletOwnerEnum owner)
    {
        _currentBullet = FindFirstInactive(_bulletList);
        _currentBullet.BulletOwner = owner;

        _currentBullet.transform.position = shootingObject.transform.position - (shootingObject.transform.right * _bulletInitialOffset);
        _currentBullet.transform.DOMove(shootingObject.transform.position - (shootingObject.transform.right * _bulletSpeed), BULLET_TWEEN_TIME).SetEase(Ease.Linear);

        _currentBullet.gameObject.SetActive(true);
    }

    public void ShootBullet(GameObject shootingObject,BulletOwnerEnum owner, Vector3 point)
    {
        _currentBullet = FindFirstInactive(_bulletList);
        _currentBullet.BulletOwner = owner;

        _currentBullet.transform.position = shootingObject.transform.position - (shootingObject.transform.right * _bulletInitialOffset);
        _currentBullet.transform.DOMove(shootingObject.transform.localPosition - ((shootingObject.transform.localPosition - point).normalized * _bulletSpeed), BULLET_TWEEN_TIME).SetEase(Ease.Linear);

        _currentBullet.gameObject.SetActive(true);
    }
}
