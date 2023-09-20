using System;

using UnityEngine;

public class Settings : MonoBehaviour
{
    [SerializeField] private string _file;

    [Space]
    [SerializeField, Min(0)] private int _defaultDifficulty;

    [Space]
    [SerializeField] private AudioMixerController _mixer;
    [SerializeField, Range(-80, 20)] private float _defaultVolume;

    private const string _volumeName = "Volume";
    private const string _difficultyName = "Difficulty";

    private float _volume;
    public float Volume 
    {
        get => _volume;
        set
        {
            _volume = value;
            _mixer.MasterVolume = _volume;
        }
    }

    private int _difficulty;
    public int Difficulty 
    { 
        get => _difficulty; 
        set => _difficulty = Mathf.Max(0, value); 
    }

    public static Settings Instance { get; private set; }

    private void Awake()
    {
        Load();
		
        if (Instance is null)
			Instance = this;
    }

    public void Save()
    {
        PlayerPrefs.SetInt(_difficultyName, _difficulty);
        PlayerPrefs.SetFloat(_volumeName, _volume);
    }

    public void Load()
    {
        if (PlayerPrefs.HasKey(_difficultyName))
            Difficulty = PlayerPrefs.GetInt(_difficultyName);
        else
            Difficulty = _defaultDifficulty;

        if (PlayerPrefs.HasKey(_volumeName))
            Volume = PlayerPrefs.GetFloat(_volumeName);
        else
            Volume = _defaultVolume;
    }
}