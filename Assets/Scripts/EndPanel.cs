using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CanvasGroup))]
public class EndPanel : MonoBehaviour
{
    private CanvasGroup _panel;
    private Player _player;
    private const int NUMBER_OF_MENUSCENE = 0;

    private void Awake()
    {
        _panel = GetComponent<CanvasGroup>();
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

    public void OnDead()
    {
        _panel.alpha = 1;
        _panel.blocksRaycasts = true;
        _panel.interactable = true;
    }

    public void OnRestartButtonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnMenuButtonClick()
    {
        SceneManager.LoadScene(NUMBER_OF_MENUSCENE);
    }
}
