using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public UnityEvent Death;
    public UnityEvent PickedCoin;

    private void Awake()
    {
        if (Death == null)
        {
            Death = new UnityEvent();
        }
    }

    public void Dead()
    {
        Death?.Invoke();
    }
}
