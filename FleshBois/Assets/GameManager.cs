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

    void Start()
    {
        gameTimer.TimerEndEvent.AddListener(EndGame);
        // todo: alien dying should also call end game
    }
    void Update()
    {
        
    }
    void StartGame(){
        currentGameState = GameState.active;
    }
    public void EndGame(){
        currentGameState = GameState.ended;
        GameEndEvent.Invoke();
    }
    void restartGame(){
        score.clearScore();
        currentGameState = GameState.idle;
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