using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class AsteroidController : MonoBehaviour
{
    [SerializeField]
    private EnemyType _type;

    [SerializeField]
    private Image _renderer;

    [SerializeField]
    private LoadSceneController _loadSceneController;

    private float _randomizedSpeedTime;
    private Vector3 _randomizedRotation;

    public EnemyType Type
    {
        get { return _type; }
        set { _type = value; }
    }

    private void OnEnable()
    {
        Init();
    }

    private void OnDisable()
    {
        StopTweens();
    }

    private void Init()
    {
        _renderer.sprite = _type.Sprite;
        transform.localScale = _type.Scale;
    }

    public void HandleMovement(Vector3 destination, EnemyType type)
    {
        _randomizedSpeedTime = Random.Range(type.SpeedMinValue, type.SpeedMaxValue);
        _randomizedRotation = new Vector3(0,0,Random.Range(type.RotationMinValue, type.RotationMaxValue));

        transform.DOMove(destination, _randomizedSpeedTime).SetEase(Ease.InSine).OnComplete(() => OnAsteroidPathEnd());
        transform.DOBlendableRotateBy(_randomizedRotation, _randomizedSpeedTime).SetEase(Ease.Linear);
    }

    public void OnAsteroidPathEnd()
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

            GameManager.Singleton.PlayerShipController.PlayDeathEffect();
            GameManager.Singleton.PlayerShipController.DisableGraphic();

            GameManager.Singleton.PlayerShipController.RespawnShip();

            GameManager.Singleton.PlayerStats.Lives--;
            GameManager.Singleton.OnDamageReceived?.Invoke();
        

            if(GameManager.Singleton.PlayerStats.Lives <= 0)
            {
                _loadSceneController.LoadScene();
            }
        }
    }

    private void StopTweens()
    {
        DOTween.Kill(transform);
    }
}
