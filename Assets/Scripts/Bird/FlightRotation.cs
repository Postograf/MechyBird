using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class FlightRotation : MonoBehaviour
{
    [SerializeField] private Vector2 _liftDirection;
    [SerializeField] private Vector2 _fallDirection;
    [SerializeField, Min(0)] private float _liftingDuration;
    [SerializeField, Min(0)] private float _fallingDuration;

    private Transform _transform;
    private Rigidbody2D _rigidbody;

    private float _liftSpeed;
    private float _fallSpeed;

    private void Awake()
    {
        _transform = transform;
        _rigidbody = GetComponent<Rigidbody2D>();

        var distance = (_liftDirection - _fallDirection).magnitude;
        _liftSpeed = distance / _liftingDuration;
        _fallSpeed = distance / _fallingDuration;
    }

    private void LateUpdate()
    {
        var requiredDirection = _rigidbody.velocity.y > 0 ? _liftDirection : _fallDirection;
        var speed = _rigidbody.velocity.y > 0 ? _liftSpeed : _fallSpeed;

        var distance = (requiredDirection - (Vector2)_transform.right).magnitude;
        var t = (speed * Time.deltaTime) / distance;
        _transform.right = Vector2.Lerp(_transform.right, requiredDirection, t);
    }
}