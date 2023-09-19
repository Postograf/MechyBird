using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class Bird : MonoBehaviour
{
    public UnityEvent Dead;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Wall>(out _))
        {
            Run.Current?.End();
            Dead?.Invoke();
        }
    }
}