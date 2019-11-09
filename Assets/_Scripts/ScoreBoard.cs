using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// File Name: ScoreBoard.cs
/// Author: Kevin Yuayan
/// Last Modified by: Kevin Yuayan
/// Date Last Modified: Nov. 9, 2019
/// Description: Scriptable Object to hold Score data
/// Revision History:
/// </summary>
[CreateAssetMenu(fileName = "ScoreBoard", menuName = "Game/ScoreBoard")]
[System.Serializable]
public class ScoreBoard : ScriptableObject
{
    public int highScore;
    public int lives;
    public int score;
}
