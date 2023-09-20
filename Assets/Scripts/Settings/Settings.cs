using System;
using System.IO;
using System.Threading.Tasks;

using UnityEngine;

public class Settings : MonoBehaviour
{
    [Serializable]
    public struct Data
    {
        [Range(-80, 20)] public float Volume;
        [Min(0)] public int Difficulty;
    }

    [SerializeField] private string _file;
    [SerializeField] private Data _default;
    [SerializeField] private AudioMixerController _mixer;

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

    private JsonConverter<Data> _json;

    public static Settings Instance { get; private set; }

    private void Awake()
    {
        _json = new(Path.Combine(Application.dataPath, _file));
        Load();
		
        if (Instance is null)
			Instance = this;
    }

    public void Save()
    {
        var data = new Data() 
        { 
            Volume = _volume, 
            Difficulty = _difficulty 
        };

        _json.Serialize(data, prettyPrint: true);
    }

    public void Load()
    {
        var data = _json.Deserialize(_default);
        Volume = data.Volume;
        Difficulty = data.Difficulty;
    }
}