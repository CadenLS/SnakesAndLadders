using System;

public class CharacterSelectionManager
{
    const string redHexCode = "#ff0000";
    const string blueHexCode = "#0000ff";
    const string yellowHexCode = "#ffff00";
    const string purpleHexCode = "#9933ff";
    const string greenHexCode = "#33cc33";
    const string orangeHexCode = "#ff9933";
    const string[] choosableColors = new string[6] { redHexCode, blueHexCode, yellowHexCode, purpleHexCode, greenHexCode, orangeHexCode };
    string[] chosenColors = new string[6];

    private int playerAmount;

    public CharacterSelectionManager()
    {
    }
    public void colorChosen(string color, int index)
    {
        string colorChosen = color.toLower();
        switch (colorchosen)
        {
            case "red":
                chosenColors[index] = redHexCode;
                break;
            case "blue":
                chosenColors[index] = blueHexCode;
                break;
            case "yellow":
                chosenColors[index] = yellowHexCode

                        break;
            case "purple":
                chosenColors[index] = purpleHexCode;
                break;
            case "green":
                chosenColors[index] = greenHexCode;
                break;
            case "orange":
                chosenColors[index] = orangeHexCode;
                break;
            case default:
                Console.WriteLine("No Valid Color detected. Please input 'red', 'blue', 'yellow', purple', 'green', or 'orange'.");
                break;
        }
    }

}