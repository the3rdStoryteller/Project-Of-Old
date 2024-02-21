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
        if (Input.GetKey(KeyCode.W) ||
            Input.GetKey(KeyCode.A) ||
            Input.GetKey(KeyCode.S) ||
            Input.GetKey(KeyCode.D)) {
                Speed = WalkSpeed;
                PS = PlayerState.Walk;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}