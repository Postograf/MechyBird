using UnityEngine;
using UnityEngine.Events;

public class Run : MonoBehaviour
{
    public UnityEvent Begun;
    public UnityEvent Ended;
    public UnityEvent<int> ScoreChanged;

    public static Run Current { get; private set; }

    private int _score;
    public int Score 
    {
        get => _score;
        set
        {
            _score = value;
            ScoreChanged?.Invoke(_score);
        }
    }

    public void Begin()
    {
        Score = 0;
        Current = this;
        Begun?.Invoke();
    }

    public void End()
    {
        Current = null;
        Ended?.Invoke();
    }
}