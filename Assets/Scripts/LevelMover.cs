using UnityEngine;

public class LevelMover : MonoBehaviour
{
    private GameState _gameData;

    private void Awake()
    {
        _gameData = FindObjectOfType<GameState>();
    }

    private void Update()
    {
        transform.Translate(Vector3.left * _gameData.GameSpeed * Time.deltaTime);
    }
}
