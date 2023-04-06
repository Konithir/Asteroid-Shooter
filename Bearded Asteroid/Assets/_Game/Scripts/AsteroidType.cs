using UnityEngine;

[CreateAssetMenu( menuName = "ScriptableObjects/Asteroids/AsteroidType")]
public class AsteroidType : ScriptableObject
{
    [SerializeField]
    private Sprite _sprite;

    [SerializeField]
    private int _points;

    [SerializeField]
    private Vector2 _size;

    public Sprite Sprite
    {
        get { return _sprite; }
    }

    public int Point
    {
        get { return _points; }
    }

    public Vector2 Size
    {
        get { return _size; }
    }
}
