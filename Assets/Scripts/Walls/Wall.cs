using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Wall : MonoBehaviour 
{
    public Transform Transform { get; private set; }
    public Rigidbody2D Rigidbody { get; private set; }

    private void Awake()
    {
        Transform = transform;
        Rigidbody = GetComponent<Rigidbody2D>();
    }
}