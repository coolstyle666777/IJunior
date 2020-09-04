using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _patterns;
    [SerializeField] private float _spawnInterval;
    private Pool _pool;
    private Player _player;

    private float _elapsedTime;

    private void Awake()
    {
        _pool = FindObjectOfType<Pool>();
        _player = FindObjectOfType<Player>();
    }

    private void OnEnable()
    {
        _player.Dead += OnDead;
    }

    private void OnDisable()
    {
        _player.Dead -= OnDead;
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if(_elapsedTime >= _spawnInterval)
        {
            _elapsedTime = 0;
            SpawnPattern();
        }
    }

    private void SpawnPattern()
    {
        int numberOfPattern = Random.Range(0, _patterns.Length);
        foreach (Transform childPoolObject in _patterns[numberOfPattern].transform)
        {
            if(childPoolObject.TryGetComponent(out PoolObject poolObject))
            {
                PoolObject spawnObject = _pool.GetObject(poolObject);
                spawnObject.transform.position = childPoolObject.position;
                spawnObject.gameObject.SetActive(true);
            }        
        }       
    }

    private void OnDead()
    {
        gameObject.SetActive(false);
    }
}
