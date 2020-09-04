using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(TextMeshProUGUI))]
public class CoinsText : MonoBehaviour
{   
    private TextMeshProUGUI _text;
    private Player _player;
    private int _amount;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
        _player = FindObjectOfType<Player>();
    }

    private void Start()
    {
        SetAmountText();
    }

    private void OnEnable()
    {
        _player.CoinPicked += OnCoinPicked;
    }

    private void OnDisable()
    {
        _player.CoinPicked -= OnCoinPicked;
    }

    private void SetAmountText()
    {
        _text.SetText(_amount.ToString());
    }

    public void OnCoinPicked()
    {
        _amount++;
        SetAmountText();
    }
}
