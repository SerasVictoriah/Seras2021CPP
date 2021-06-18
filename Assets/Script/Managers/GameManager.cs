using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour

    

{

    static GameManager _instance = null;

    public static GameManager instance
    {
        get { return _instance; }
        set { _instance = value; }
    }

    public int maxLives = 3;

    int _score = 0;
    public int score
    {
        get { return _score; }
        set
        {
            _score = value;
            Debug.Log("Current Score Is: " + _score);
        }
    }


    int _lives;

    public int lives
    {
        get { return _lives; }
        set
        {
            currentCanvas = FindObjectOfType<CanvasManager>();
            if (_lives > value)
            {
                //Respawn();
            }
            _lives = value;
            



            if (_lives > maxLives)
            {
                _lives = maxLives;
            }

            if (_lives < 0)
            {
                //game over code goes here
                
                //death animation - into load scene
                //SceneManager.LoadScene("GameOver");
                playerInstance.GetComponent<Player_Movement>().IsDead();

                Invoke("EndGame", 1f);

            }

            Debug.Log("Current Lives Are: " + _lives);
            currentCanvas.SetLivesText();
        }
    }

    public GameObject playerInstance;
    public GameObject playerPrefab;
    public LevelManager currentLevel;

    CanvasManager currentCanvas;

    // Start is called before the first frame update
    void Start()
    {
        if (instance)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        currentCanvas = FindObjectOfType<CanvasManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (SceneManager.GetActiveScene().name == "SampleScene")
                SceneManager.LoadScene("TitleScreen");
            else if (SceneManager.GetActiveScene().name == "TitleScreen")
                SceneManager.LoadScene("SampleScene");
            else if (SceneManager.GetActiveScene().name == "GameOver")
                SceneManager.LoadScene("TitleScreen");
        }

        if (Input.GetKeyDown(KeyCode.Backspace))
            QuitGame();
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void SpawnPlayer(Transform spawnLocation)
    {
        CameraFollow mainCamera = FindObjectOfType<CameraFollow>();

        if (mainCamera)
        {
            mainCamera.player = Instantiate(playerPrefab, spawnLocation.position, spawnLocation.rotation);
            playerInstance = mainCamera.player;
        }
        else
        {
            SpawnPlayer(spawnLocation);
        }
    }

    public void EndGame()
    {
        SceneManager.LoadScene("GameOver");
    }


    public void Respawn()
    {
        playerInstance.transform.position = currentLevel.spawnLocation.position;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("TitleScreen");
    }
}