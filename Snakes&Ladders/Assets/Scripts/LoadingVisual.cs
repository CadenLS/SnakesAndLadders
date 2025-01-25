using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoadingVisual : MonoBehaviour
{
	[SerializeField] TextMeshProUGUI loadingText;
	float loadingTimer = 1;
	int loadingState = 0;
	
	private void Start() {
		Loader.LoaderCallback();
	}
	private void Update() {
		loadingTimer -= Time.deltaTime;
		if (loadingTimer <= 0) {
			loadingTimer = 1;
			loadingState += 1;
			switch (loadingState) {
				case 0:
					loadingText.text = "Loading";
					break;
				case 1:
					loadingText.text = "Loading.";
					break;
				case 2:
					loadingText.text = "Loading..";
					break;
				case 3:
					loadingText.text = "Loading...";
					loadingState = -1;
					break;
			}
		}
	}
}
