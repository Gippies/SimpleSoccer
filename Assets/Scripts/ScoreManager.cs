using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    Dictionary<Goal, int> scores;
    // Start is called before the first frame update
    void Start()
    {
        scores = new Dictionary<Goal, int>();

        Goal[] goals = (Goal[]) Enum.GetValues(typeof(Goal));
        foreach (Goal g in goals) {
            scores[g] = 0;
        }
    }

    public void addScore(Goal g) {
        scores[g]++;
    }

    public int getScore(Goal g) {
        return scores[g];
    }

    public void resetScore() {
        foreach (Goal key in scores.Keys) {
            scores[key] = 0;
        }
    }
}

public enum Goal {
    East,
    West
}
