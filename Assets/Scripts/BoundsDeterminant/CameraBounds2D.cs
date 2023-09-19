using UnityEngine;

public class CameraBounds2D : BoundsDeterminant
{
    [Tooltip("Main camera for default")]
    [SerializeField] private Camera _camera;
    [SerializeField] private Vector2 _additionalSize;

    public override Bounds GetBounds()
    {
        if (_camera is null)
            _camera = Camera.main;

        var extents = _camera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        var size = (Vector2)extents * 2 + _additionalSize;
        return new Bounds((Vector2)_camera.transform.position, size);
    }
}