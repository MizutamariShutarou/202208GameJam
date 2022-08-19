using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class KillCount : MonoBehaviour
{
    int _killCount;
    [SerializeField] int _totalEnemy = 0;
   [SerializeField]Text _killCountText = null;
    public void KillCountPlus()
    {
        _killCount = GameManager.Instance.DeathCount;
        _killCountText.text = "KILL : " +_killCount + " / " + _totalEnemy ; 
    }
}
