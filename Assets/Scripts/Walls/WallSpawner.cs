using System;
using System.Collections;

using UnityEngine;
using UnityEngine.Events;

using Random = UnityEngine.Random;

public class WallSpawner : MonoBehaviour
{
    [Serializable]
    public struct Difficulty
    {
        public Wall Prefab;
        public Vector2 Speed;
        public Vector2 SpawnPoint;
        public Vector2 MaxSpawnShift;
        public BoundsDeterminant SpawnPositionLimit;
        [Min(0)] public int MaxCount;
        [Min(0)] public float SpawnDelay;
    }

    [SerializeField] private Difficulty[] _difficulties;

    private Vector2 _maxShift;
    private Vector2 _spawnPoint;
    private Difficulty _difficulty;
    private ObjectPool<Wall> _pool;

    public UnityEvent<ObjectPool<Wall>.Part> WallSpawned; 

    private void Start()
    {
        var difficultyIndex = Mathf.Min(Settings.Instance.Difficulty, _difficulties.Length - 1);
        ChangeDifficulty(_difficulties[difficultyIndex]);
        
        StartCoroutine(DelayedSpawn());
    }

    private IEnumerator DelayedSpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(_difficulty.SpawnDelay);
            var part = _pool.Get();
            var wall = part.Value;
            var shift = _maxShift * Random.Range(-1, 1f);
            wall.Transform.position = _spawnPoint + shift;
            wall.Rigidbody.velocity = _difficulty.Speed;

            WallSpawned?.Invoke(part);
        }
    }

    public void ChangeDifficulty(in Difficulty difficulty)
    {
        _difficulty = difficulty;

        var limit = _difficulty.SpawnPositionLimit.GetBounds();
        _spawnPoint = limit.ClosestPoint(_difficulty.SpawnPoint);
        _maxShift = (Vector2)limit.ClosestPoint(_spawnPoint + _difficulty.MaxSpawnShift) - _spawnPoint;

        _pool?.Clear();
        _pool = new(_difficulty.Prefab, _difficulty.MaxCount, _spawnPoint);
    }
}