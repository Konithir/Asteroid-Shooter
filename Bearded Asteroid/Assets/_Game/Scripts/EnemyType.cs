using UnityEngine;

[CreateAssetMenu( menuName = "Bearded_Asteroid/Enemies/EnemyType")]
public class EnemyType : ScriptableObject
{
    [SerializeField]
    private Sprite _sprite;

    [SerializeField]
    private int _points;

    [SerializeField]
    private Vector3 _scale;

    [Range(0, float.MaxValue)]
    [SerializeField]
    private float _speedMinValue;

    [Range(0, float.MaxValue)]
    [SerializeField]
    private float _speedMaxValue;

    [SerializeField]
    private float _rotationMinValue;

    [SerializeField]
    private float _rotationMaxValue;

    [SerializeField]
    private bool _shootsBullets;

    public Sprite Sprite
    {
        get { return _sprite; }
    }

    public int Point
    {
        get { return _points; }
    }

    public Vector3 Scale
    {
        get { return _scale; }
    }

    public float SpeedMinValue
    {
        get { return _speedMinValue; }
    }

    public float SpeedMaxValue
    {
        get { return _speedMaxValue; }
    }

    public float RotationMinValue
    {
        get { return _rotationMinValue; }
    }

    public float RotationMaxValue
    {
        get { return _rotationMaxValue; }
    }

    public bool ShootsBullets
    {
        get { return _shootsBullets; }
    }
}
