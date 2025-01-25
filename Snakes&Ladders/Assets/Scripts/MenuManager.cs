using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
	public Button playButton;
	[SerializeField] Button quitButton;

	private void Start() {
		playButton.onClick.AddListener(() => {
			loadGame();
		});
		quitButton.onClick.AddListener(() => {
			quitGame();
		});
	}

	private void loadGame() {
		Loader.Load(Loader.scenes.TestBoard);
	}
	private void quitGame() {
		Application.Quit();
	}
}
