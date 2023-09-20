using UnityEngine;
using UnityEngine.Audio;

public class AudioMixerController : MonoBehaviour
{
    [SerializeField] private AudioMixer _mixer;
    [SerializeField] private string _masterVolumeName;

    public float MasterVolume
    {
        get => GetFloat(_masterVolumeName);
        set => _mixer.SetFloat(_masterVolumeName, value);
    }

    public float GetFloat(string name)
    {
        if (_mixer.GetFloat(name, out var value))
            return value;
        return default;
    }
}