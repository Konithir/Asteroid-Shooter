using TMPro;
using UnityEngine;

public class EndGameInfoController : MonoBehaviour
{
    [SerializeField]
    private PlayerStats _player;

    [SerializeField]
    private TextMeshProUGUI _scoreText;

    [SerializeField]
    private TextMeshProUGUI _levelText;

    [SerializeField]
    private TextMeshProUGUI _nameText;

    private void Start()
    {
        UpdateScore();
        UpdateLives();
        UpdateName();
    }

    public void UpdateScore()
    {
        _scoreText.text = _player.Score.ToString();
    }

    public void UpdateLives()
    {
        _levelText.text = _player.LevelAchievedName.ToString();
    }

    private void UpdateName()
    {
        _nameText.text = _player.Name;
    }
}
