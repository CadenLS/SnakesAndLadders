using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	[SerializeField] private Block[] grid;
	[SerializeField] Button rollButton;
    [SerializeField] private DiceRoller2D diceRoller;

    [SerializeField] private float snappingDistance = 0.1f;
	[SerializeField] Player[] players;
	int currentPlayer = 0;

	[SerializeField] private TextMeshProUGUI currenPlayerVisual;
	[SerializeField] private float moveSpeed = 4;
	bool splineMovment = false;
	int pointIndex = 0;

	private void Start() 
	{
        diceRoller.OnRoll += HandleDiceRoll;
    }

	private void Update() {
		Player player = players[currentPlayer];
		// if spline movement handle that
		if (splineMovment) {
			if (pointIndex <= grid[player.currentPosition - 1].points.Length) {
				player.transform.position = Vector2.MoveTowards(player.transform.position, grid[player.currentPosition - 1].points[pointIndex].transform.position, Time.deltaTime * moveSpeed);

				if (player.transform.position == grid[player.currentPosition - 1].points[pointIndex].transform.position) {
					pointIndex++;
				}
			} else {
				splineMovment = false;
			}
		} else if (player.currentPosition != player.nextPosition) { //handle normal movmement
			player.transform.position = Vector3.MoveTowards(player.transform.position, grid[player.nextPosition - 1].transform.position, Time.deltaTime * moveSpeed);
		}
		if (Vector3.Distance(player.transform.position, grid[player.nextPosition - 1].transform.position) < snappingDistance &&
			player.currentPosition != player.nextPosition) {
			//check if it is a snake or ladder
			player.transform.position = grid[player.nextPosition - 1].transform.position;
			player.currentPosition = player.nextPosition;
			if (grid[player.nextPosition - 1].extraMovement) {

				player.nextPosition = grid[player.currentPosition - 1].movement;
				pointIndex = 0;
				splineMovment = true;
			} else {
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

    public void OnRoll()
    {
        // Disable roll button
        rollButton.enabled = false;

        // Trigger the dice roll
        diceRoller.RollDice();
    }

    private void HandleDiceRoll(int movement)
    {
        MovePlayer(movement);
    }

    private void MovePlayer(int movement)
    {
        Player player = players[currentPlayer];
        player.nextPosition = movement + player.currentPosition;

        if (player.nextPosition > grid.Length)
        {
            player.nextPosition = player.currentPosition;
            AdvanceToNextPlayer();
        }
        else if (player.nextPosition == grid.Length)
        {
            Debug.Log($"Player {currentPlayer + 1} wins!");
        }
    }

    private void AdvanceToNextPlayer()
    {
        currentPlayer++;
        if (currentPlayer >= players.Length)
        {
            currentPlayer = 0;
        }

        currenPlayerVisual.text = currentPlayer.ToString();
        rollButton.enabled = true; // Enable roll button
    }

    //public void OnRoll() {
    //	//disable roll button
    //	rollButton.enabled = false;
    //	//get random number
    //	int movement = Random.Range(1, 7);
    //	//display random number
    //	//move player
    //	MovePlayer(movement);
    //}

    //private void MovePlayer(int Movement) {
    //	Player player = players[currentPlayer];
    //	player.nextPosition = Movement + player.currentPosition;
    //	if (player.nextPosition > grid.Length) {
    //		player.nextPosition = player.currentPosition;
    //		//update to next player UI and code
    //		currentPlayer += 1;
    //		if (currentPlayer >= players.Length) {
    //			currentPlayer = 0;
    //		}
    //		currenPlayerVisual.text = currentPlayer.ToString();
    //		//enable roll button
    //		rollButton.enabled = true;
    //	} else if (player.nextPosition == grid.Length) {
    //		//win
    //	}
    //}
}
