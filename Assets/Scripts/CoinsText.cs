using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(TextMeshProUGUI))]
public class CoinsText : MonoBehaviour
{
    private int _amount;
    private TextMeshProUGUI _text;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        SetAmountText();
    }

    private void SetAmountText()
    {
        _text.SetText(_amount.ToString());
    }

    public void AddCoin()
    {
        _amount++;
        SetAmountText();
    }
}
