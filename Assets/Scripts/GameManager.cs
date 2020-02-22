/*
  Copyright (C) 2016 - 2020 MWSOFT
  This program is free software: you can redistribute it and/or modify
  it under the terms of the GNU General Public License as published by
  the Free Software Foundation, either version 3 of the License, or
  (at your option) any later version.
  This program is distributed in the hope that it will be useful,
  but WITHOUT ANY WARRANTY; without even the implied warranty of
  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
  GNU General Public License for more details.
  You should have received a copy of the GNU General Public License
  along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{

    public GameObject playerPrefab;
    public Text scoreText;
    public Text currentScoreText;
    public Text highScoreText;
    public Image twicePowerUp;
    public Image magnetPowerUp;

    public int score = 0;
    public int bestScore;
    public bool playGame = false;
    public bool replayGame = false;
    public bool resetHasBeenClicked = false;
    public Image myImage;


    private bool gameStarted;
    private bool gamePaused = false;
    private bool unpauseGame = false;
    private TimeManager timeManager;
    private GameObject player;
    private GameObject floor;
    private GameObject gameOverWindow;
    private GameObject playButton;
    private Spawner spawner;
    private TreasureSpawner treasureSpawner;
    private PixelPerfectCamera pixelPerfectCamera;
    private GameAdManager gameAdManager;
    public AudioClip backgroundMusic;
    public AudioSource music;
    

    void Awake()
    {
        floor = GameObject.Find("Foreground");
        player = GameObject.Find("Player");
        spawner = GameObject.Find("Spawner").GetComponent<Spawner>();
        treasureSpawner = GameObject.Find("TreasureSpawner").GetComponent<TreasureSpawner>();
        timeManager = GetComponent<TimeManager>();
        pixelPerfectCamera = GameObject.Find("Main Camera").GetComponent<PixelPerfectCamera>();
        gameOverWindow = GameObject.Find("GameOverWindow");
        playButton = GameObject.Find("StartGame");
        myImage = GameObject.Find("StartGame").GetComponent<Button>().GetComponent<Image>();
        gameAdManager = GameObject.Find("GameManager").GetComponent<GameAdManager>();
        config();

        DontDestroyOnLoad(this);
    }

    // Use this for initialization
    void Start()
    {

        playButton.SetActive(true);
        gameOverWindow.SetActive(false);



        twicePowerUp.enabled = false;
        magnetPowerUp.enabled = false; 


        var floorHeight = floor.transform.localScale.y;

        var pos = floor.transform.position;
        pos.x = 0;
        pos.y = -((Screen.height / pixelPerfectCamera.pixelsToUnits) / 2) + (floorHeight / 2);
        floor.transform.position = pos;

        spawner.active = false;
        treasureSpawner.active = false;

        PlayerPrefs.SetInt("shield", 0);

        Time.timeScale = 0;

        scoreText.text = "SCORE : ";

        bestScore = PlayerPrefs.GetInt("BestScore");

        if (PlayerPrefs.GetString("SoundOnOff").Equals("On"))
        {
            GameObject.Find("BackgroundMusic").GetComponent<AudioSource>().Play();
        }
        else
        {
            GameObject.Find("BackgroundMusic").GetComponent<AudioSource>().Pause();
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (gameStarted)
        {
            if (player.GetComponent<DetectCollision>().twicePowerUpEnabled == true)
            {
                twicePowerUp.enabled = true;

            }
            else if (player.GetComponent<DetectCollision>().twicePowerUpEnabled == false)
            {
                twicePowerUp.enabled = false;

            }


            if (player.GetComponent<TreasureFollowPlayer>().magnetPowerUpEnabled == true)
            {
                magnetPowerUp.enabled = true;
            }
            else if (player.GetComponent<TreasureFollowPlayer>().magnetPowerUpEnabled == false)
            {
                magnetPowerUp.enabled = false;

            }

            if (player.GetComponent<DetectCollision>().touchedSpikes == true)
            {
                OnPlayerKilled();
                player.SetActive(false);

            }

            if(gamePaused == true)
            {
                timeManager.ManipulateTime(0, 5.5f);
                ChangeImage("play");
                gameStarted = false;

            }
        }


        if (!gameStarted && Time.timeScale == 0)
        {

            if (playGame == true)
            {
                ChangeImage("pause");
                timeManager.ManipulateTime(1, 1f);
                ResetGame();
                playGame = false;
            }


            if (replayGame == true) {
                //timeManager.ManipulateTime(1, 1f);
                //ReplayGame();
                int scene = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadScene(scene, LoadSceneMode.Single);
                replayGame = false;
            }

        }

        if (gamePaused == true)
        {
            if (unpauseGame == true)
            {
                ChangeImage("pause");
                timeManager.ManipulateTime(1, 1f);
                playGame = false;
                gamePaused = false;
                gameStarted = true;
                unpauseGame = false;
            }

        }


    }

    public void OnPlayerKilled()
    {
        if (PlayerPrefs.GetString("SoundOnOff").Equals("On"))
        {
            GameObject.Find("BackgroundMusic").GetComponent<AudioSource>().Pause();
        }
        PlayerPrefs.SetInt("shield", 0);
        spawner.active = false;
        treasureSpawner.active = false;
        playButton.SetActive(false);

        var playerDestroyScript = player.GetComponent<DestroyOffscreen>();
        playerDestroyScript.DestroyCallback -= OnPlayerKilled;

        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        
        timeManager.ManipulateTime(0, 5.5f);
        gameStarted = false;

        score = player.GetComponent<DetectCollision>().score;

        if (score > bestScore)
        {
            bestScore = score;
            PlayerPrefs.SetInt("BestScore", bestScore);

        }

        

        gameOverWindow.SetActive(true);

        currentScoreText.text = "SCORE : " + score;
        highScoreText.text = "HIGHSCORE : " + PlayerPrefs.GetInt("BestScore");

        player.GetComponent<DetectCollision>().touchedSpikes = false;

        gameAdManager.ShowBanner();

    }

    public void ResetGame()
    {
        gameAdManager.HideBanner();
        gameOverWindow.SetActive(false);

        spawner.active = true;
        treasureSpawner.active = true;
        playButton.SetActive(true);

        GameObjectUtil gameObjectUtil = new GameObjectUtil();

        player = gameObjectUtil.Instantiate(playerPrefab, new Vector3(-200, (Screen.height / pixelPerfectCamera.pixelsToUnits) / 2, 0));

        var playerDestroyScript = player.GetComponent<DestroyOffscreen>();
        playerDestroyScript.DestroyCallback += OnPlayerKilled;

        gameStarted = true;

        scoreText.text = "SCORE : ";
        player.GetComponent<DetectCollision>().score = 0;

    }

    public void ReplayGame()
    {
        gameAdManager.HideBanner();
        gameOverWindow.SetActive(false);
        player.GetComponent<DetectCollision>().score = 0;


        spawner.active = true;
        treasureSpawner.active = true;
        playButton.SetActive(true);

        GameObjectUtil gameObjectUtil = new GameObjectUtil();

        player = gameObjectUtil.Instantiate(playerPrefab, new Vector3(-200, (Screen.height / pixelPerfectCamera.pixelsToUnits) / 2, 0));

        var playerDestroyScript = player.GetComponent<DestroyOffscreen>();
        playerDestroyScript.DestroyCallback += OnPlayerKilled;

        gameStarted = true;

        scoreText.text = "SCORE : ";

        if (PlayerPrefs.GetString("SoundOnOff").Equals("On"))
        {
            GameObject.Find("BackgroundMusic").GetComponent<AudioSource>().Play();
        }

    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene("Start");
    }

    public void ClickedOnPlay()
    {
        if(gameStarted == true)
        {
            gamePaused = true;
        }
        else
        {
            if(gamePaused == true)
            {
                unpauseGame = true;
            }
            else
            {
                playGame = true;
            }
        }
        
    }

    public void ClickedOnReplay()
    {
        replayGame = true;
        resetHasBeenClicked = true;
    }

    public void ChangeImage(string newImageTitle)
    {
        myImage.sprite = Resources.Load<Sprite>(newImageTitle);
    }

    public void config()
    {
#if UNITY_ANDROID

        

        QualitySettings.vSyncCount = 0;

        QualitySettings.antiAliasing = 0;

        if (QualitySettings.GetQualityLevel() == 0)
        {
            Application.targetFrameRate = 30;
            QualitySettings.shadowCascades = 0;
            QualitySettings.shadowDistance = 15;
        }

        else if (QualitySettings.GetQualityLevel() == 5)
        {
            Application.targetFrameRate = 30;
            QualitySettings.shadowCascades = 2;
            QualitySettings.shadowDistance = 15;
        }

        Screen.sleepTimeout = SleepTimeout.NeverSleep;

#endif



#if UNITY_STANDALONE_WIN
         
         Application.targetFrameRate = 60;
         QualitySettings.vSyncCount = 0; 
         
         if (QualitySettings.GetQualityLevel() == 0)
         {
             QualitySettings.antiAliasing = 0;
         }
         
         if (QualitySettings.GetQualityLevel() == 5)
         {
             QualitySettings.antiAliasing = 8;
         }
         
#endif
    }


}
