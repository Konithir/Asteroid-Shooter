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
    private string _levelAchievedName;

    public string Name
    {
        get { return _name; }
        set { _name = value; }
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

    public string LevelAchievedName
    {
        get { return _levelAchievedName; }
        set { _levelAchievedName = value; }
    }

    public void Reset()
    {
        _score = 0;
        _lives = 3;
        _levelAchievedName = "1";
    }
}