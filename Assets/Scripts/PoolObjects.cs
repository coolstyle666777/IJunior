using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PoolObjects : MonoBehaviour
{
    [SerializeField] private GameObject[] _prefabs;
    [SerializeField] private int _startCapacity;

    private List<GameObject> _pool;

    public static PoolObjects Instance;

    private void Awake()
    {
        _pool = new List<GameObject>();
        Instance = this;
    }

    private void Start()
    {
        for (int i = 0; i < _startCapacity; i++)
        {
            foreach (GameObject prefab in _prefabs)
            {
                AddObjectToPool(prefab);
            }
        }
    }

    private GameObject AddObjectToPool(GameObject prefab)
    {
        GameObject poolObject = Instantiate(prefab, transform);
        poolObject.SetActive(false);
        _pool.Add(poolObject);
        return poolObject;
    }

    public GameObject GetObject(GameObject prefab)
    {
        GameObject result = _pool.FirstOrDefault(p => p.activeSelf == false && p.name == prefab.name + "(Clone)");
        if (result != null)
        {
            return result;
        }
        else
        {
            return AddObjectToPool(prefab);
        }
    }
}
