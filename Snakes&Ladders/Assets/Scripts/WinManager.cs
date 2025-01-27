using TMPro;
using UnityEngine;

public class WinManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI congratsText;

    private void Start()
    {
        // Retrieve data from PlayerPrefs
        int winningPlayer = PlayerPrefs.GetInt("WinningPlayer");
        string colorHex = PlayerPrefs.GetString("WinningColor");

        // Update the text and its color
        congratsText.text = $"Congrats Player {winningPlayer}!";
        if (ColorUtility.TryParseHtmlString($"#{colorHex}", out Color playerColor))
        {
            congratsText.color = playerColor;
        }
    }
}
