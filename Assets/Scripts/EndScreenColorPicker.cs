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

        ScoreToMessage(_messageText, coin.Score);
    }

    void ScoreToMessage(TextMeshProUGUI message, int score)
    {

        if (score < 5)
        {
            message.text = $"[Just {6 - score} more points for the token]";
        }
        else if (score == 5)
        {
            message.text = $"[Just 1 more point for the token]";
        }
        else
        {
            message.text = "[your token is: \"Fleece_Navidad!\"]\n[that's how spanish llamas say \"Merry Christmas\"]";
        }

        message.text += "\n\n";

        switch (score)
        {
            case 0: message.text +=  "I don't even know how you did this..."; break; 
            case 1: message.text +=  "What's the nicest way to say \"Noob\"?"; break;
            case 2: message.text +=  "2 points, eh? It's... a start..."; break;
            case 3: message.text +=  "Yes! And now do three more!"; break;
            case 4: message.text +=  "Almost there!"; break;
            case 5: message.text +=  "Soooo close..."; break;
            case 6: message.text +=  "You did it(, you bloody minimalist)!"; break;
            case 7: message.text +=  "You did great!"; break;
            case 8: message.text +=  "How much higher can you go?"; break;
            case 9: message.text += "Did you get this score by chance, or do you want to read all messages?"; break;
            case 10: message.text += "It's 2am, and I wanna sleep... no more messages"; break;
            case 42: message.text +=  "No more messages, except for this one maybe"; break;
            default: message.text +=  "Sorry, there's no more silly messages"; break;
        }
    }
}
