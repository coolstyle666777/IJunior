using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObject : MonoBehaviour
{
    [SerializeField] private Types _objectType;
    public Types ObjectType => _objectType;

    public enum Types
    {
        Coin,
        Spike
    }
}
