using System;

public class CharacterSelectionManager
{
	public CharacterSelectionManager()
	{
		string redHexCode = "#ff0000";
		string blueHexCode = "#0000ff";
		string yellowHexCode = "#ffff00";
		string purpleHexCode = "#9933ff";
		string greenHexCode = "#33cc33";
		string orangeHexCode = "#ff9933";
        string[] choosableColors = new string[6] { redHexCode, blueHexCode, yellowHexCode, purpleHexCode, greenHexCode, orangeHexCode};
		string[] chosenColors = new string[6];

		public void colorChosen (string color, int index)
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

			}
		}
    }
}
