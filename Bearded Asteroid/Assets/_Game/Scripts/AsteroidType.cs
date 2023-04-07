using UnityEngine;

[CreateAssetMenu( menuName = "ScriptableObjects/Asteroids/AsteroidType")]
public class AsteroidType : ScriptableObject
{
    [SerializeField]
    private Sprite _sprite;

    [SerializeField]
    private int _points;

    [SerializeField]
    private Vector3 _scale;

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
}
