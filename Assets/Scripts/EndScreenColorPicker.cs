using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndScreenColorPicker : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI _scoreText;

    [SerializeField]
    TextMeshProUGUI _messageText;

    private void OnEnable()
    {
        TextMeshProUGUI[] textMeshes = GetComponentsInChildren<TextMeshProUGUI>();

        CoinPositioning coin = GameObject.FindGameObjectWithTag("Coin").GetComponent<CoinPositioning>();

        _scoreText.text = "" + coin.Score;
    }
}
