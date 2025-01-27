using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	[SerializeField] private Block[] grid;
	[SerializeField] Button rollButton;
    [SerializeField] private DiceRoller2D diceRoller;
    [SerializeField] GameObject playerPrefab;

    [SerializeField] private float snappingDistance = 0.1f;
	[SerializeField] List<Player> players;
	int currentPlayer = 0;
    int playerText;

	[SerializeField] private TextMeshProUGUI currenPlayerVisual;
	[SerializeField] private float moveSpeed = 4;
	bool splineMovment = false;
	int pointIndex = 0;

	private void Start() 
	{
        diceRoller.OnRoll += HandleDiceRoll;
        int i = 0;
        foreach (var p in CharacterSelectionManager.chosenColors) {
            GameObject player = Instantiate(playerPrefab,new Vector3(-3, -0.75f, 0), Quaternion.identity);
            players.Add(player.GetComponent<Player>());
            players[i].UpdateColor(p);
            i++;
        }
    }

	private void Update() 
    {
		Player player = players[currentPlayer];

        if (splineMovment)
        {
            if (pointIndex <= grid[player.currentPosition - 1].points.Length)
            {
                player.transform.position = Vector2.MoveTowards(
                    player.transform.position,
                    grid[player.currentPosition - 1].points[pointIndex].transform.position,
                    Time.deltaTime * moveSpeed
                );

                if (player.transform.position == grid[player.currentPosition - 1].points[pointIndex].transform.position)
                {
                    pointIndex++;
                }
            }
            else
            {
                splineMovment = false;
            }
        }
        else if (player.currentPosition != player.nextPosition)
        {
            player.transform.position = Vector3.MoveTowards(
                player.transform.position,
                grid[player.nextPosition - 1].transform.position,
                Time.deltaTime * moveSpeed
            );
        }

        if (Vector3.Distance(player.transform.position, grid[player.nextPosition - 1].transform.position) < snappingDistance &&
            player.currentPosition != player.nextPosition)
        {
            player.transform.position = grid[player.nextPosition - 1].transform.position;
            player.currentPosition = player.nextPosition;

            if (grid[player.nextPosition - 1].extraMovement)
            {
                player.nextPosition = grid[player.currentPosition - 1].movement;
                pointIndex = 0;
                splineMovment = true;
            }
            else
            {
                currentPlayer = (currentPlayer + 1) % players.Count;
                currenPlayerVisual.text = (currentPlayer + 1).ToString();
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
        if (player.nextPosition >= grid.Length)
        {
            Debug.Log($"Player {currentPlayer + 1} wins!");
            LoadCongratsScene(currentPlayer);
        }
    }

    private void AdvanceToNextPlayer()
    {
        currentPlayer++;
        if (currentPlayer >= players.Count)
        {
            currentPlayer = 0;
        }

        currenPlayerVisual.text = currentPlayer.ToString();
        rollButton.enabled = true; // Enable roll button
    }

    private void LoadCongratsScene(int winnerIndex)
    {
        // Pass the winner's index and color to the "Congrats" scene
        PlayerPrefs.SetInt("WinningPlayer", winnerIndex + 1);
        PlayerPrefs.SetString("WinningColor", UnityEngine.ColorUtility.ToHtmlStringRGB(players[winnerIndex].GetColor()));
        SceneManager.LoadScene("WinScene");
    }

}
