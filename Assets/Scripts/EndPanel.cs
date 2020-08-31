using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CanvasGroup))]
public class EndPanel : MonoBehaviour
{
    private CanvasGroup _panel;

    private void Awake()
    {
        _panel = GetComponent<CanvasGroup>();
    }

    public void ShowPanel()
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
        SceneManager.LoadScene(0);
    }
}
