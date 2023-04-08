using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameInfoUIControler : MonoBehaviour
{
    [SerializeField]
    private PlayerStats _player;

    [SerializeField]
    private TextMeshProUGUI _scoreText;

    [SerializeField]
    private List<Image> _livesImages;

    private void Start()
    {
        SubscribeToEvents();
    }

    private void SubscribeToEvents()
    {
        GameManager.Singleton.OnPointChange.AddListener(UpdateScore);
        GameManager.Singleton.OnDamageReceived.AddListener(UpdateLives);
    }

    public void UpdateScore()
    {
        _scoreText.text = _player.Score.ToString();
    }

    public void UpdateLives()
    {
        for(int i = 0; i < _livesImages.Count; i++)
        {
            if(i < _player.Lives)
            {
                _livesImages[i].gameObject.SetActive(true);
            }
            else
            {
                _livesImages[i].gameObject.SetActive(false);
            }
        }
    }
}
