
public class ShootingEnemyController : BasicEnemyController
{
    protected override void OnEnable()
    {
        Init();
        StartShooting();
    }

    protected override void OnDisable()
    {
        StopTweens();
        CancelInvoke();
    }

    private void StartShooting()
    {
        InvokeRepeating(nameof(Shoot),2,2);
    }

    private void Shoot()
    {
        GameManager.Singleton.BulletManager.ShootBullet(gameObject, BulletOwnerEnum.Enemy, GameManager.Singleton.PlayerShipController.transform.localPosition);
    }
}
