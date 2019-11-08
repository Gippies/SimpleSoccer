using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text westScoreBoard;
    public Text eastScoreBoard;

    Dictionary<Goal, int> scores;
    Dictionary<Goal, Text> scoreBoards;
    // Start is called before the first frame update
    void Start()
    {
        scores = new Dictionary<Goal, int> {
            {Goal.West, 0},
            {Goal.East, 0}
        };
        scoreBoards = new Dictionary<Goal, Text> {
            {Goal.West, westScoreBoard},
            {Goal.East, eastScoreBoard}
        };

        FindObjectOfType<BallBehavior>().OnEnterGoal += addScore;
    }

    public void addScore(Goal g) {
        scores[g]++;
        scoreBoards[g].text = scores[g].ToString();
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
