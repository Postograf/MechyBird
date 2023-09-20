using UnityEngine;

public class CameraBounds2D : BoundsDeterminant
{
    [SerializeField] private Vector2 _additionalSize;

    private Camera _camera;

    public override Bounds GetBounds()
    {
        if (_camera == null)
            _camera = Camera.main;

        var extents = _camera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        var size = (Vector2)extents * 2 + _additionalSize;
        return new Bounds((Vector2)_camera.transform.position, size);
    }
}