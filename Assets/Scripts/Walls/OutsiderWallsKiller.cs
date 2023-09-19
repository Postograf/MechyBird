using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;

using Part = ObjectPool<Wall>.Part;

public class OutsiderWallsKiller : MonoBehaviour
{
    [SerializeField] private BoundsDeterminant _determinant;

    private Bounds _bounds;
    private List<Part> _parts = new();

    public UnityEvent<Part> WallDestroyed;

    private void Awake()
    {
        _bounds = _determinant.GetBounds();
    }

    private void LateUpdate()
    {
        for (int i = 0; i < _parts.Count; i++)
        {
            var part = _parts[i];
            if (_bounds.Contains(part.Value.Transform.position) == false)
            {
                part.Dispose();
                _parts.RemoveAt(i);
                WallDestroyed?.Invoke(part);
            }
        }
    }

    public void AddWall(Part part)
    {
        _parts.Add(part);
    }

    public void RemoveWall(Part part)
    {
        for (int i = 0; i < _parts.Count; i++)
        {
            var iPart = _parts[i];

            if (iPart.Value == part.Value)
            {
                _parts.RemoveAt(i);
                break;
            }
        }
    }
}