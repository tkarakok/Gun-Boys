using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : Singleton<EventManager>
{
    public delegate void StateActions();
    public StateActions MainMenu;
    public StateActions InGame;
    public StateActions EndGame;
    public StateActions GameOver;

    private void Start() {
        MainMenu += SubscribeAllEvents;
        MainMenu();
    }

    void SubscribeAllEvents(){
        #region InGame
            InGame += ()=> StateManager.Instance.State = State.InGame;
            InGame += UIManager.Instance.UpdateEnemyCounterText;
        #endregion

        #region GameOver
            GameOver += () =>StateManager.Instance.State = State.GameOver;
            GameOver += UIManager.Instance.GameOver;
        #endregion

        #region EndGame
            EndGame += () =>StateManager.Instance.State = State.EndGame;
            EndGame += UIManager.Instance.EndGame;
            EndGame += GameManager.Instance.EndGameConfetti;
        #endregion
    }
}
