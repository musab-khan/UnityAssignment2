using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStateManager : MonoBehaviour
{
    public Text scoreObject;
    public static int killScore = 0;
    private int lives = 5;
    [HideInInspector] public static int livesRemain = 5;

    public Image[] hearts;
    public Sprite haveLife;
    public Sprite lostLife;

    // Update is called once per frame
    void Update()
    {
        scoreObject.text = "KILLS: " + killScore;

        for (int i = 0 ; i < lives ; i++)
        {
            if (i < livesRemain)
                hearts[i].sprite = haveLife;
            else
                hearts[i].sprite = lostLife;
        }
    }
}
