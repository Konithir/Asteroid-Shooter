using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class AsteroidController : MonoBehaviour
{
    [SerializeField]
    private AsteroidType _type;

    [SerializeField]
    private Vector3 _rotateValue;

    [SerializeField]
    private Image _renderer;

    private float _randomizedTime;

    public AsteroidType Type
    {
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

    public void HandleMovement(Vector3 destination, float minTime, float maxTime)
    {
        _randomizedTime = Random.Range(minTime, maxTime);
        transform.DOMove(destination, _randomizedTime).SetEase(Ease.InSine).OnComplete(() => OnAsteroidPathEnd());
        transform.DOBlendableRotateBy(_rotateValue, _randomizedTime).SetEase(Ease.Linear);
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
        }
    }

    private void StopTweens()
    {
        DOTween.Kill(transform);
    }
}
