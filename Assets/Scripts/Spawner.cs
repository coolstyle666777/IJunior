using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _patterns;
    [SerializeField] private float _spawnInterval;

    private float _elapsedTime;

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
        foreach (Transform childTransform in _patterns[numberOfPattern].transform)
        {
            GameObject spawnObject = PoolObjects.Instance.GetObject(childTransform.gameObject);
            spawnObject.transform.position = childTransform.position;
            spawnObject.SetActive(true);
        }       
    }
}
