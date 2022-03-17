using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : Singleton<UIManager>
{
    [Header("Panels")]
    public GameObject mainMenuPanel;
    public GameObject inGamePanel;
    public GameObject endGamePanel;
    public GameObject gameOverPanel;
    [Header("In Game Text")]
    public Text enemyCounterText;

    #region Private Fields
        private GameObject _currentPanel;
    #endregion

    private void Start() {
        _currentPanel = mainMenuPanel;
    }

    #region Panel Change Function
    /// <summary>
    /// we changing panels
    /// </summary>
    /// <param name="openPanel"> opening panel </param>
        public void PanelChange(GameObject openPanel){
            _currentPanel.SetActive(false);
            openPanel.SetActive(true);
            _currentPanel = openPanel;
        }
    #endregion

    #region StartButton
        public void StartButton(){
            PanelChange(inGamePanel);
            EventManager.Instance.InGame();
        }
    #endregion

    #region In Game UI Text Update
        public void UpdateEnemyCounterText(){
            enemyCounterText.text = GameManager.Instance.AliveEnemy.ToString() + " / " + GameManager.Instance.EnemySize.ToString();
        }
    #endregion

    #region GameOver
        public void GameOver(){
            PanelChange(gameOverPanel);
        }
    #endregion

    #region EndGame
        public void EndGame(){
            PanelChange(endGamePanel);
        }
    #endregion
}
