using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    float _gameTime;
    int _deathCounts;
    bool _isAllKilled;
    /// <summary> �C���Q�[���̃^�C�}�[ </summary>
    public float GameTime => _gameTime;
    /// <summary> �G��|������ </summary>
    public int DeathCount => _deathCounts;
    /// <summary> �G��S���|�������ǂ����̃t���O(�S���|������true) </summary>
    bool IsAllKilled => _isAllKilled;
    static public GameManager Instance = new GameManager();

    /// <summary>
    /// �G��|������Ă�
    /// </summary>
    public void EnemyDeath()
    {
        _deathCounts++;
    }

    /// <summary>
    /// �S�Ă̓G��|������Ă�
    /// </summary>
    public void OllKilled()
    {
        _isAllKilled = true;
    }

    void Update()
    {
        if (!PauseManager.Instance.IsPause)
        {
            _gameTime += Time.deltaTime;
        }
    }
}
