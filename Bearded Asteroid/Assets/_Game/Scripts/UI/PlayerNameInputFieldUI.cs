using UnityEngine;
using TMPro;

public class PlayerNameInputFieldUI : MonoBehaviour
{
    [SerializeField]
    private PlayerStats _player;

    [SerializeField]
    private TMP_InputField _inputField;

    private void Start()
    {
        LoadSavedName();
    }

    private void LoadSavedName()
    {
        _inputField.text = _player.Name;
    }
}
