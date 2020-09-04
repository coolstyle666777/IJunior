using UnityEngine;

public class LevelMover : MonoBehaviour
{
    [SerializeField] private float _gameSpeed = 12;
    private Player _player;

    private void Awake()
    {
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
        transform.Translate(Vector3.left * _gameSpeed * Time.deltaTime);
    }

    public void OnDead()
    {
        _gameSpeed = 0;
    }
}
