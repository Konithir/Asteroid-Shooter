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

    [SerializeField]
    private RectTransform _rectTransform;

    private float _randomizedTime;

    private void OnEnable()
    {
        Init();
    }

    private void Init()
    {
        _renderer.sprite = _type.Sprite;
        _rectTransform.sizeDelta = _type.Size;
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
}
