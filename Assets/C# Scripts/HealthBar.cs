using UnityEngine;
using UnityEngine.UI;

/* HealthBar.cs
*   Author: Ethan Sowle
*   Description: A class to display the player's health.
*   Parametes: None
*   Return: None
*   Date Created: 4/12/2024
*   Date Modified: 4/12/2024
*/

public class HealthBar : MonoBehaviour
{
    public Player player;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < player.health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
        }
    }
}
