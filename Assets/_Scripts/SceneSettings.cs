using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SceneSettings", menuName = "Scene/Settings")]
[System.Serializable]
public class SceneSettings : ScriptableObject
{
    [Header("Scene Configuration")]
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
