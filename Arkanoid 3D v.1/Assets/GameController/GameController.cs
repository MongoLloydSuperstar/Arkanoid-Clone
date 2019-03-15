using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController gameController = null;

    public Transform paddle;
    public Transform ball;

    public bool spawnBall;
    public Vector2 initialVelocity;
    public Vector2 paddleSpawnPosition;
    public Vector2 ballSpawnRelative;


    public int Score { get; set; }

    private void Awake()
    {
        if (gameController == null) {
            gameController = this;
        }
        else if (gameController != this) {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        StartNewGame();
    }

    private void StartNewGame()
    {
        Vector3 fixedBallsSpawnPoint = paddleSpawnPosition + ballSpawnRelative;
        Instantiate(paddle, paddleSpawnPosition, Quaternion.identity);
        Instantiate(ball, fixedBallsSpawnPoint, Quaternion.identity);
    }

    public void BrickDestroyed(int points)
    {
        Score += points;
    }

    public void BricksEmpty()
    {
        SceneManager.LoadScene("Main");
    }   
}
