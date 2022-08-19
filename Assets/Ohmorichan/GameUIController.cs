using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIController: MonoBehaviour
{
    [SerializeField] GameObject _resurltUI;
    [SerializeField] Text _score;
    [SerializeField] Text _resultText;
    // Start is called before the first frame update
    void Start()
    {
        _resurltUI.SetActive(false);
    }

   

    // Update is called once per frame
    public void Result()
    {
        _resurltUI.SetActive(true);
        _resultText.text = _score.text;
    }
}
