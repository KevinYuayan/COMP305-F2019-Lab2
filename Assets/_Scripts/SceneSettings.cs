using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// File Name: SceneSettings.cs
/// Author: Kevin Yuayan
/// Last Modified by: Kevin Yuayan
/// Date Last Modified: Nov. 9, 2019
/// Description: Scriptable Object to setup Scene Objects
/// Revision History:
/// </summary>
[CreateAssetMenu(fileName = "SceneSettings", menuName = "Scene/Settings")]
[System.Serializable]
public class SceneSettings : ScriptableObject
{
    [Header("Scene Configuration")]
    public Scene scene;
    public SoundClip activeSoundClip;

    [Header("Scene Labels")]
    public bool scoreLabelEnabled;
    public bool livesLabelEnabled;

    [Header("ScoreBoard Labels")]
    public bool endLabelEnabled;
    public bool startLabelEnabled;
    public bool highScoreLabelEnabled;

    [Header("Scene Buttons")]
    public bool startButtonActive;
    public bool restartButtonActive;
}
