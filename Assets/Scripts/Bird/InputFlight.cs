using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class InputFlight : MonoBehaviour
{
    [SerializeField] private float _flightSpeed;
    [SerializeField] private float _fallingSpeed;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.touchCount > 0)
            _rigidbody.velocity = Vector2.up * _flightSpeed;
        else
            _rigidbody.velocity = Vector2.down * _fallingSpeed;
    }
}