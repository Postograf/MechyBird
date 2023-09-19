using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class ObjectPool<T>
    where T : MonoBehaviour
{
    public struct Part
    {
        public T Value { get; private set; }
        public ObjectPool<T> Owner { get; private set; }

        public Part(ObjectPool<T> owner, T value)
        {
            Value = value;
            Owner = owner;
        }

        public void Dispose()
        {
            if (Owner is not null)
            {
                Owner.Release(Value);
                Owner = null;
            }
        }
    }

    private T _prefab;
    private Vector3 _storagePoint;
    private Stack<T> _pool;

    public ObjectPool(T prefab, int startCount, Vector3 storagePoint)
    {
        _prefab = prefab;
        _storagePoint = storagePoint;
        _pool = new Stack<T>(startCount);

        for (int i = 0; i < startCount; i++)
        {
            Release(Spawn());
        }
    }

    public Part Get()
    {
        if (_pool.Count > 0)
            return new Part(this, _pool.Pop());
        else
            return new Part(this, Spawn());
    }

    public void Release(T part)
    {
        part.gameObject.SetActive(false);
        part.transform.position = _storagePoint;
        _pool.Push(part);
    }

    private T Spawn()
    {
        return Object.Instantiate(_prefab, _storagePoint, Quaternion.identity);
    }
}