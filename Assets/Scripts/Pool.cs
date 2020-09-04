using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Pool : MonoBehaviour
{
    [SerializeField] private PoolObject[] _prefabs;
    [SerializeField] private int _startCapacity;
    private List<PoolObject> _pool;

    private void Awake()
    {
        _pool = new List<PoolObject>();
    }

    private void Start()
    {
        for (int i = 0; i < _startCapacity; i++)
        {
            foreach (PoolObject prefab in _prefabs)
            {
                AddObjectToPool(prefab);
            }
        }
    }

    private PoolObject AddObjectToPool(PoolObject prefab)
    {
        PoolObject poolObject = Instantiate(prefab, transform);
        poolObject.gameObject.SetActive(false);
        _pool.Add(poolObject);
        return poolObject;
    }

    public PoolObject GetObject(PoolObject prefab)
    {
        PoolObject result = _pool.FirstOrDefault(p => p.gameObject.activeSelf == false && p.ObjectType == prefab.ObjectType);
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
