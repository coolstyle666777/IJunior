using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public UnityAction Dead;
    public UnityAction CoinPicked;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Coin coin))
        {
            CoinPicked?.Invoke();
        }
    }

    public void Death()
    {
        Dead?.Invoke();
    }
}
