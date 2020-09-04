using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(RectTransform), typeof(CanvasGroup))]
public class AnimationOfPanel : MonoBehaviour
{
    [SerializeField] private float _reverseDuration;
    [SerializeField] private float _vanishDuration;
    [SerializeField] private float _playSoundTime;
    [SerializeField] private float _reverseSoundTime;
    private Tween _panelTween;
    private CanvasGroup _panelCanvas;
    private RectTransform _panelTransform;
    private MenuSounds _sounds;
    private AuthorsText _authorsText;
    private bool _isAuthorsAnimationPlaying;

    private void Awake()
    {
        _panelTransform = GetComponent<RectTransform>();
        _panelCanvas = GetComponent<CanvasGroup>();
        _sounds = FindObjectOfType<MenuSounds>();
        _authorsText = FindObjectOfType<AuthorsText>();
    }

    private void ShowPannel()
    {
        _panelTween.Kill();
        _panelTransform.DOScale(Vector3.one, _reverseDuration).OnKill(ShowPanelComplete);
        _sounds.ReverseSoundStartFrom(_reverseSoundTime);
        _sounds.StopPlaySound();
        _authorsText.ReverseText();
    }

    private void ShowPanelComplete()
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

    public void HidePannel()
    {
        _panelTween = _panelTransform.DOScale(Vector3.zero, _vanishDuration);
        _panelCanvas.interactable = false;
        _panelCanvas.blocksRaycasts = false;
        _sounds.PlaySoundStartFrom(_playSoundTime);
        _authorsText.MoveText();
        _isAuthorsAnimationPlaying = true;
    }
}
