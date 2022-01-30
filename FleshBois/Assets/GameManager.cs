using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour {
    private static GameManager _instance;
    
    public static GameManager Instance { get { return _instance; } }
    public enum GameState {idle, active, ended};
    public GameState currentGameState = GameState.idle;
    public UnityEvent GameEndEvent = new UnityEvent();
    public Timer gameTimer;
    public ScoreKeeper score;
    
    public Animator gameOverScreen;
    public AlienSpawner alienSpawner;
    public OperatingTable operatingTable;

    void Start()
    {
        gameTimer.TimerEndEvent.AddListener(EndGame);
        // todo: alien dying should also call end game
    }
    void Update()
    {
        
    }
    public void StartGame(){
        if (currentGameState == GameState.active) return;

        alienSpawner.StartLaunchSequence();
        gameTimer.StartTimer();
        currentGameState = GameState.active;
    }

    public void StartGameDelayed(){
        StartCoroutine(WaitToStart());
    }

    IEnumerator WaitToStart()
    {
        yield return new WaitForSeconds(2.0f);
        StartGame();
    }

    public void EndGame(){
        currentGameState = GameState.ended;
        GameEndEvent.Invoke();

        operatingTable.Yeet();
        alienSpawner.DisposeOfAlien();
        gameOverScreen.SetTrigger("Open");
        gameTimer.EndTimer();
    }
    void restartGame(){
        score.clearScore();
        currentGameState = GameState.idle;
        gameOverScreen.SetTrigger("Close");
    }
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }
}