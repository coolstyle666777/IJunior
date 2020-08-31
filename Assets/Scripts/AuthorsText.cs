using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(RectTransform))]
public class AuthorsText : MonoBehaviour
{
    [SerializeField] private float _endPositionY;
    [SerializeField] private float _startPositionY;
    [SerializeField] private float _playSpeed;
    [SerializeField] private float _reverseDuration;
    private RectTransform _textTransform;
    private Tween _textTween;

    private void Awake()
    {
        _textTransform = GetComponent<RectTransform>();
    }

    public void PlayText()
    {
        _textTween = _textTransform.DOLocalMoveY(_endPositionY, _playSpeed).SetSpeedBased();
    }

    public void ReverseText()
    {
        _textTween.Kill();
        _textTransform.DOLocalMoveY(_startPositionY, _reverseDuration);
    }
}
