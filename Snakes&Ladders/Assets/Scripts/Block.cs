using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {
    [SerializeField] public bool extraMovement =  false;
    [SerializeField] public int movement = 0; // position to go to 
    [SerializeField] public GameObject[] points;
}
