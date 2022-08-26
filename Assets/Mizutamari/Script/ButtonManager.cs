using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] Button _button;
    [SerializeField] int _enemyNum;
    private void Start()
    {
        _button.gameObject.SetActive(false);
    }
    private void Update()
    {
        if(GameManager.Instance.DeathCount >= _enemyNum)
        {
            _button.gameObject.SetActive(true);
        }
    }
}
