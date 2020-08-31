using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    [SerializeField] float _gameSpeed;
    public float GameSpeed => _gameSpeed;

    public void StopGame()
    {
        _gameSpeed = 0;
    }
}
