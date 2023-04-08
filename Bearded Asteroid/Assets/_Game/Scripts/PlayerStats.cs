using UnityEngine;

[CreateAssetMenu(menuName = "Bearded_Asteroid/Statistics/PlayerStats")]
public class PlayerStats : ScriptableObject
{
    [SerializeField]
    private string _name;

    [SerializeField]
    private int _score;

    [SerializeField]
    private int _lives;

    [SerializeField]
    private int _level;

    public string Name
    {
        get { return _name; }
    }

    public int Score
    {
        get { return _score; }
        set { _score = value; }
    }

    public int Lives
    {
        get { return _lives; }
        set { _lives = value; }
    }

    public int Level
    {
        get { return _level; }
        set { _level = value; }
    }
}