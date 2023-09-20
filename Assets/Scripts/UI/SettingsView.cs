using UnityEngine;
using UnityEngine.UI;

public class SettingsView : MonoBehaviour
{
    [SerializeField] private Slider _volume;
    [SerializeField] private Slider _difficulty;
	
	private void OnEnable() 
	{
        _volume.value = Settings.Instance.Volume;
        _difficulty.value = Settings.Instance.Difficulty;
	}

    private void Start()
    {
        _volume.onValueChanged.AddListener((x) => Settings.Instance.Volume = x);
        _difficulty.onValueChanged.AddListener((x) => Settings.Instance.Difficulty = (int)x);
		
		gameObject.SetActive(false);
    }
}