using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Player.cs
*   Author: Ethan Sowle
*   Description: A class to represent a player in the game.
*   Parametes: None
*   Return: None
*   Date Created: 2/6/2024
*   Date Modified: 2/6/2024
*/

public enum PlayerState {
    Idle,
    Walk,
    Run,
    Attack,
}

public class Player : MonoBehaviour {
    public PlayerState PS;
    public float Speed = 0f;
    public float WalkSpeed = 6f;

    void KeyboardInput() {
        if (KeyboardInput.GetKey(KeyCode.W) ||
            KeyboardInput.GetKey(KeyCode.A) ||
            KeyboardInput.GetKey(KeyCode.S) ||
            KeyboardInput.GetKey(KeyCode.D)) {
                Speed = WalkSpeed;
                PS = PlayerState.Walk;
        }
    }
}