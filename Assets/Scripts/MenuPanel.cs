using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.EventSystems;

[RequireComponent(typeof(RectTransform), typeof(CanvasGroup))]
public class MenuPanel : MonoBehaviour
{
    [SerializeField] private float _vanishDuration;
    [SerializeField] private float _reverseDuration;
    [SerializeField] private float _playSoundTime;
    [SerializeField] private float _reverseSoundTime;
    private MenuSounds _sounds;
    private AuthorsText _authorsText;
    private RectTransform _panelTransform;
    private CanvasGroup _panelCanvas;
    private bool _isAuthorsAnimationPlaying;
    private Tween _panelTween;

    private void Awake()
    {
        _panelTransform = GetComponent<RectTransform>();
        _panelCanvas = GetComponent<CanvasGroup>();
        _authorsText = FindObjectOfType<AuthorsText>();
        _sounds = FindObjectOfType<MenuSounds>();
    }

    public void OnPlayButtonClick()
    {
        SceneManager.LoadScene(1);
    }

    public void OnQuitButtonClick()
    {
        Application.Quit();
    }

    public void OnAuthorsButtonClick()
    {
        HidePannel();
        _authorsText.PlayText();
        _sounds.PlaySoundStartFrom(_playSoundTime);
        _isAuthorsAnimationPlaying = true;
    }

    public void HidePannel()
    {
        _panelTween = _panelTransform.DOScale(Vector3.zero, _vanishDuration);
        _panelCanvas.interactable = false;
        _panelCanvas.blocksRaycasts = false;
    }

    public void ShowPannel()
    {
        _panelTween.Kill();
        _panelTransform.DOScale(Vector3.one, _reverseDuration).OnKill(ShowPanelComplete);
        _sounds.ReverseSoundStartFrom(_reverseSoundTime);
        _sounds.StopPlaySound();
        _authorsText.ReverseText();
    }

    public void ShowPanelComplete()
    {
        _panelCanvas.interactable = true;
        _panelCanvas.blocksRaycasts = true;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _isAuthorsAnimationPlaying)
        {
            _isAuthorsAnimationPlaying = false;
            ShowPannel();
        }
    }
}
