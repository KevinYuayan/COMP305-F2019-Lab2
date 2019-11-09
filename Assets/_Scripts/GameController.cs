using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System.Linq;
using System;

/// <summary>
/// File Name: BackgroundController.cs
/// Author: Kevin Yuayan
/// Last Modified by: Kevin Yuayan
/// Date Last Modified: Nov. 9, 2019
/// Description: Controler for the GameController object
/// Revision History:
/// </summary>
public class GameController : MonoBehaviour
{
    [Header("Scene Game Objects")]
    public GameObject cloud;
    public GameObject island;
    public int numberOfClouds;
    public List<GameObject> clouds;

    [Header("Audio Sources")]
    public SoundClip activeSoundClip;
    public AudioSource[] audioSources;

    [Header("Scoreboard")]
    [SerializeField]
    private int _lives;

    [SerializeField]
    private int _score;

    public Text livesLabel;
    public Text scoreLabel;
    public Text highScoreLabel;

    //public HighScoreSO highScoreSO;

    [Header("UI Control")]
    public GameObject startLabel;
    public GameObject startButton;
    public GameObject endLabel;
    public GameObject restartButton;

    [Header("UI Control")]
    public ScoreBoard scoreBoard;

    [Header("Scene Settings")]
    public List<SceneSettings> sceneSettings;
    public SceneSettings activeSceneSettings;
    // public properties
    public int Lives
    {
        get
        {
            return _lives;
        }

        set
        {
            _lives = value;
            scoreBoard.lives = _lives;

            if (_lives < 1 && activeSceneSettings.scene != Scene.END)
            {
                scoreBoard.lives = _lives;
                SceneManager.LoadScene("End");
            }
            else
            {
                livesLabel.text = "Lives: " + _lives;
            }
           
        }
    }

    public int Score
    {
        get
        {
            return _score;
        }

        set
        {
            _score = value;
            scoreBoard.score = _score;

            if (scoreBoard.highScore < _score)
            {
                scoreBoard.highScore = _score;
            }
            scoreLabel.text = "Score: " + _score;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        GameObjectInitialization();
        SceneConfiguration();
    }

    private void GameObjectInitialization()
    {
        startLabel = GameObject.Find("StartLabel");
        endLabel = GameObject.Find("EndLabel");
        startButton = GameObject.Find("StartButton");
        restartButton = GameObject.Find("RestartButton");

        //highScoreSO = Resources.FindObjectsOfTypeAll<HighScoreSO>()[0] as HighScoreSO;
    }


    private void SceneConfiguration()
    {

        // Linq statement
        // finds the sceneSetting that matches the Scene enum parsed from GetActiveScene().name
        var query = from settings in sceneSettings
                    where settings.scene == (Scene)Enum.Parse(typeof(Scene), SceneManager.GetActiveScene().name.ToUpper())
                    select settings;

        activeSceneSettings = query.ToList().First();

        {
            if(activeSceneSettings.scene == Scene.MAIN || activeSceneSettings.scene == Scene.START)
            {
                Lives = 5;
                Score = 0;
            }
            else
            {
                Lives = scoreBoard.lives;
                Score = scoreBoard.score;
            }

            activeSoundClip = activeSceneSettings.activeSoundClip;

            scoreLabel.enabled = activeSceneSettings.scoreLabelEnabled;
            livesLabel.enabled = activeSceneSettings.livesLabelEnabled;

            highScoreLabel.enabled = activeSceneSettings.highScoreLabelEnabled;
            endLabel.SetActive(activeSceneSettings.endLabelEnabled);
            startLabel.SetActive(activeSceneSettings.startLabelEnabled);

            startButton.SetActive(activeSceneSettings.startButtonActive);
            restartButton.SetActive(activeSceneSettings.restartButtonActive);

            highScoreLabel.text = "HighScore: " + scoreBoard.highScore;
        }



        if ((activeSoundClip != SoundClip.NONE) && (activeSoundClip != SoundClip.NUM_OF_CLIPS))
        {
            AudioSource activeAudioSource = audioSources[(int)activeSoundClip];
            activeAudioSource.playOnAwake = true;
            activeAudioSource.loop = true;
            activeAudioSource.volume = 0.5f;
            activeAudioSource.Play();
        }



        // creates an empty container (list) of type GameObject
        clouds = new List<GameObject>();

        for (int cloudNum = 0; cloudNum < numberOfClouds; cloudNum++)
        {
            clouds.Add(Instantiate(cloud));
        }

        Instantiate(island);
    }

    // Event Handlers
    public void OnStartButtonClick()
    {
        SceneManager.LoadScene("Main");
    }

    public void OnRestartButtonClick()
    {
        SceneManager.LoadScene("Main");
    }
}
