using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class TriggerScoreGiver : MonoBehaviour
{
	[SerializeField] private int _score;
	
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Bird>(out _) && Run.Current is not null)
            Run.Current.Score += _score;
    }
}