using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class BasicEnemyController : MonoBehaviour
{
    [SerializeField]
    private EnemyType _type;

    [SerializeField]
    private Image _renderer;

    private float _randomizedSpeedTime;
    private Vector3 _randomizedRotation;

    public EnemyType Type
    {
        get { return _type; }
        set { _type = value; }
    }

    protected virtual void OnEnable()
    {
        Init();
    }

    protected virtual void OnDisable()
    {
        StopTweens();
    }

    protected void Init()
    {
        _renderer.sprite = _type.Sprite;
        transform.localScale = _type.Scale;
    }

    public void HandleMovement(Vector3 destination, EnemyType type)
    {
        _randomizedSpeedTime = Random.Range(type.SpeedMinValue, type.SpeedMaxValue);
        _randomizedRotation = new Vector3(0,0,Random.Range(type.RotationMinValue, type.RotationMaxValue));

        transform.DOMove(destination, _randomizedSpeedTime).SetEase(Ease.InSine).OnComplete(() => OnEnemyPathEnd());
        transform.DOBlendableRotateBy(_randomizedRotation, _randomizedSpeedTime).SetEase(Ease.Linear);
    }

    public void OnEnemyPathEnd()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        HandleColisions(other);
    }

    private void HandleColisions(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            GameManager.Singleton.PlayerShipController.HandleDeath();
        }
    }

    protected void StopTweens()
    {
        DOTween.Kill(transform);
    }
}
