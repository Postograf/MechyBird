using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class FlightSound : MonoBehaviour
{
    [SerializeField] private AudioSource _sound;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void LateUpdate()
    {
        if (
			Vector2.Dot(_rigidbody.velocity, Vector2.up) > 0 
			&& _sound.isPlaying == false
		)
            _sound.Play();
    }
}