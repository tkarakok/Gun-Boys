using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public LevelSettings levelSettings;
    [Header("Finish Confetti")]
    public GameObject[] confetti;

    private int enemySize;
    private int aliveEnemy;
    #region Capsullation
    public int EnemySize { get => enemySize; set => enemySize = value; }
    public int AliveEnemy { get => aliveEnemy; set => aliveEnemy = value; }
    #endregion


    private void Start()
    {
        enemySize = levelSettings.enemySize;
        aliveEnemy = levelSettings.enemySize;
    }

    public void EndGameConfetti(){
        for (int i = 0; i < confetti.Length; i++)
        {
            confetti[i].SetActive(true);
            confetti[i].GetComponent<ParticleSystem>().Play();
        }
    }

    public void MinusEnemy(){
        aliveEnemy --;
        if (aliveEnemy == 0)
        {
            EventManager.Instance.EndGame();
        }
    }
}
