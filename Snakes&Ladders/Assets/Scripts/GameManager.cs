using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Block[] grid;
	[SerializeField] Button rollButton;

	[SerializeField] private float snappingDistance = 0.1f;
    [SerializeField] Player[] players;
    int currentPlayer = 0;

	[SerializeField] private TextMeshProUGUI currenPlayerVisual;



	private void Start() {
		
	}

	private void Update() {
		//handle spline movment
		Player player = players[currentPlayer];
		if (player.currentPosition != player.nextPosition) {
			player.transform.position = Vector3.Lerp(player.transform.position, grid[player.nextPosition-1].transform.position, Time.deltaTime);
			if (Vector3.Distance(player.transform.position, grid[player.nextPosition-1].transform.position) < snappingDistance) {
				player.transform.position = grid[player.nextPosition-1].transform.position;
				player.currentPosition = player.nextPosition;
				//update to next player UI and code
				currentPlayer += 1;
				if (currentPlayer >= players.Length) {
					currentPlayer = 0;
				}
				currenPlayerVisual.text = currentPlayer.ToString();
				//enable roll button
				rollButton.enabled = true;
			}
		}
	}

	public void OnRoll() {
		//disable roll button
		rollButton.enabled = false;
		//get random number
		int movement = Random.Range(1, 7);
		//display random number
		//move player
		MovePlayer(movement);
	}

	private void MovePlayer(int Movement) {
		Player player = players[currentPlayer];
		player.nextPosition = Movement + player.currentPosition;
		if (player.nextPosition > grid.Length) {
			player.nextPosition = player.currentPosition;
			//update to next player UI and code
			currentPlayer += 1;
			if (currentPlayer >= players.Length) {
				currentPlayer = 0;
			}
			currenPlayerVisual.text = currentPlayer.ToString();
			//enable roll button
			rollButton.enabled = true;
		} else if (player.nextPosition == grid.Length){
			//win
		}
	}
}
