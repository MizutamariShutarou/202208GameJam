using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    float _gameTime;
    int _deathCounts;
    bool _isAllKilled;
    /// <summary> インゲームのタイマー </summary>
    public float GameTime => _gameTime;
    /// <summary> 敵を倒した数 </summary>
    public int DeathCount 
    {
        get { return _deathCounts; }
        set { _deathCounts = value; }
    }
    /// <summary> 敵を全員倒したかどうかのフラグ(全員倒したらtrue) </summary>
    public bool IsAllKilled => _isAllKilled;
    static public GameManager Instance = new GameManager();

    [SerializeField, Tooltip("倒す敵の数")] int _maxEnemyNum = 10;

    /// <summary>
    /// 敵を倒したら呼ぶ
    /// </summary>
    public void EnemyDeath()
    {
        _deathCounts++;
    }

    /// <summary>
    /// 全ての敵を倒したら呼ぶ
    /// </summary>
    public void OllKilled()
    {
        if(_deathCounts >= _maxEnemyNum)
        {
            _isAllKilled = true;
        }
    }

    void Update()
    {
        if (!PauseManager.Instance.IsPause)
        {
            _gameTime += Time.deltaTime;
        }
    }
}
