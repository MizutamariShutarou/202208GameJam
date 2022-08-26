using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    float _gameTime;
    int _deathCounts;
    bool _isAllKilled;
    /// <summary> ƒCƒ“ƒQ[ƒ€‚Ìƒ^ƒCƒ}[ </summary>
    public float GameTime => _gameTime;
    /// <summary> “G‚ğ“|‚µ‚½” </summary>
    public int DeathCount 
    {
        get { return _deathCounts; }
        set { _deathCounts = value; }
    }
    /// <summary> “G‚ğ‘Sˆõ“|‚µ‚½‚©‚Ç‚¤‚©‚Ìƒtƒ‰ƒO(‘Sˆõ“|‚µ‚½‚çtrue) </summary>
    public bool IsAllKilled => _isAllKilled;
    static public GameManager Instance = new GameManager();

    [SerializeField, Tooltip("“|‚·“G‚Ì”")] int _maxEnemyNum = 10;

    /// <summary>
    /// “G‚ğ“|‚µ‚½‚çŒÄ‚Ô
    /// </summary>
    public void EnemyDeath()
    {
        _deathCounts++;
    }

    /// <summary>
    /// ‘S‚Ä‚Ì“G‚ğ“|‚µ‚½‚çŒÄ‚Ô
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
