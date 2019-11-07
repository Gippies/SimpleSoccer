using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    int westScore;
    int eastScore;
    // Start is called before the first frame update
    void Start()
    {
        westScore = 0;
        eastScore = 0;
    }

    public void addScore(Goal g) {
        if (g == Goal.West)
            westScore++;
        else if (g == Goal.East)
            eastScore++;
    }

    public int getScore(Goal g) {
        if (g == Goal.West)
            return westScore;
        else if (g == Goal.East)
            return eastScore;
        else
            return -1;
    }

    public void resetScore() {
        westScore = 0;
        eastScore = 0;
    }
}

public enum Goal {
    East,
    West
}
