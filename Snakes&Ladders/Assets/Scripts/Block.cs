using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {
    [SerializeField] public bool extraMovement =  false;
    [SerializeField] public int movement = 0; // positive for the ladder, negative for the snakes
}
