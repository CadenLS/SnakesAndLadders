using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public static class CharacterSelectionManager
{
	static Color redHexCode = new Color(1f, 0f, 0f);
	static Color blueHexCode = new Color(0f, 0f, 1f);
	static Color yellowHexCode = new Color(1f, 1f, 0f);
	static Color purpleHexCode = new Color(.31f, .11f, 1f);
	static Color greenHexCode = new Color(.11f, .50f, .11f);
	static Color orangeHexCode = new Color(1f, .31f, .1f);
	public static string[] chosableColors = { "red", "blue", "yellow", "purple", "green", "orange" };
    public static List<Color> chosenColors = new List<Color>();

    static private int playerAmount;


	public static bool checkColor(string color) {
		foreach (var c in chosenColors) {
			if (ColorSwitch(color) == c) {
				return false;
			}
		}
		return true;
	}


	public static void colorChosen(string color, int index) {
		if (checkColor(color)) {
			if (chosenColors.Count-1 < index) {
				chosenColors.Add(ColorSwitch(color));
			} else {

				chosenColors[index] = ColorSwitch(color);
			}

		}
	}

    public static Color ColorSwitch(string color) {
		string colorChosen = color.ToLower();
		switch (colorChosen) {
			case "red":
				return redHexCode;
			case "blue":
				return blueHexCode;
			case "yellow":
				return yellowHexCode;
			case "purple":
				return purpleHexCode;
			case "green":
				return greenHexCode;
			case "orange":
				return orangeHexCode;
		}
		return Color.white;
	}

}