using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelect : MonoBehaviour {
	int selectedPlayer;
	int textPlayer;
	[SerializeField] TextMeshProUGUI chosenText;

    [SerializeField] GameObject player1Arrow;
    [SerializeField] GameObject player2Arrow;
    [SerializeField] GameObject player3Arrow;
    [SerializeField] GameObject player4Arrow;

    [SerializeField] Button player1;
	[SerializeField] Button player2;
	[SerializeField] Button player3;
	[SerializeField] Button player4;
	[SerializeField] Button addPlayer;
	[SerializeField] Button redColor;
	[SerializeField] Button blueColor;
	[SerializeField] Button yellowColor;
	[SerializeField] Button purpleColor;
	[SerializeField] Button greenColor;
	[SerializeField] Button orangeColor;

	[SerializeField] Button playGame;

	private void Start() {

		UpdateVisual();
		player1.onClick.AddListener(() => {
			selectedPlayer = 0;
			UpdateVisual();
		});
		player2.onClick.AddListener(() => {
			selectedPlayer = 1;
			UpdateVisual();
		}); 
		player3.onClick.AddListener(() => {
			selectedPlayer = 2;
			UpdateVisual();
		}); 
		player4.onClick.AddListener(() => {
			selectedPlayer = 3;
			UpdateVisual();
		});
		addPlayer.onClick.AddListener(() => {
			foreach (var c in CharacterSelectionManager.chosableColors) {
				if (CharacterSelectionManager.checkColor(c)) {
					CharacterSelectionManager.colorChosen(c, CharacterSelectionManager.chosenColors.Count);
					break;
				}
			}
			UpdateVisual();
		});
		redColor.onClick.AddListener(() => {
			CharacterSelectionManager.colorChosen("red", selectedPlayer);
			UpdateVisual();
		});
		blueColor.onClick.AddListener(() => {
			CharacterSelectionManager.colorChosen("blue", selectedPlayer);
			UpdateVisual();
		});
		yellowColor.onClick.AddListener(() => {
			CharacterSelectionManager.colorChosen("yellow", selectedPlayer);
			UpdateVisual();
		});
		purpleColor.onClick.AddListener(() => {
			CharacterSelectionManager.colorChosen("purple", selectedPlayer);
			UpdateVisual();
		});
		greenColor.onClick.AddListener(() => {
			CharacterSelectionManager.colorChosen("green", selectedPlayer);
			UpdateVisual();
		});
		orangeColor.onClick.AddListener(() => {
			CharacterSelectionManager.colorChosen("orange", selectedPlayer);
			UpdateVisual();
		});

		playGame.onClick.AddListener(() => {
			Loader.Load(Loader.scenes.GameBoard);
		});
	}

	private void UpdateVisual() {
		player1.enabled = false;
		player2.enabled = false;
		player3.enabled = false;
		player4.enabled = false;

        player1Arrow.SetActive(false);
        player2Arrow.SetActive(false);
        player3Arrow.SetActive(false);
        player4Arrow.SetActive(false);

        int i = 0;
		foreach (var c in CharacterSelectionManager.chosenColors) {
			switch (i) {
				case 0:
					player1.enabled = true;
					player1.GetComponent<Image>().color = c;
					break;
				case 1:
					player2.enabled = true;
					player2.GetComponent<Image>().color = c;
					break;
				case 2:
					player3.enabled = true;
					player3.GetComponent<Image>().color = c;
					break;
				case 3:
					player4.enabled = true;
					player4.GetComponent<Image>().color = c;
					break;
			}
			i++;
		}

        switch (selectedPlayer)
        {
            case 0:
                player1Arrow.SetActive(true);
                break;
            case 1:
                player2Arrow.SetActive(true);
                break;
            case 2:
                player3Arrow.SetActive(true);
                break;
            case 3:
                player4Arrow.SetActive(true);
                break;
        }


        textPlayer = selectedPlayer + 1;
		chosenText.text = textPlayer.ToString();
	}
}
