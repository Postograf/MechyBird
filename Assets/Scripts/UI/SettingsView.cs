using UnityEngine;
using UnityEngine.UI;

public class SettingsView : MonoBehaviour
{
    [SerializeField] private Slider _volume;
    [SerializeField] private Slider _difficulty;

    private void Start()
    {
        _volume.value = Settings.Instance.Volume;
        _difficulty.value = Settings.Instance.Difficulty;

        _volume.onValueChanged.AddListener((x) => Settings.Instance.Volume = x);
        _difficulty.onValueChanged.AddListener((x) => Settings.Instance.Difficulty = (int)x);
    }
}