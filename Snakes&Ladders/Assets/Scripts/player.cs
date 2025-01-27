    using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
	[SerializeField] SpriteRenderer playerImage;

    public int currentPosition = 1;
    public int nextPosition = 1;

	public void UpdateColor(Color color) {
		playerImage.color = color;
	}

    public Color GetColor()
    {
        return playerImage.color;
    }

}
