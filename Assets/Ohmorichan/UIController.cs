using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] GameObject _Title;
    [SerializeField] GameObject _maegaki;
    [SerializeField] GameObject _maegaki2;
    void Start()
    {
        _maegaki.SetActive(false);
        _maegaki2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartUI()
    {
        _Title.SetActive(false);
        _maegaki.SetActive(true);
    }

    public void StartUI2()
    {
        _maegaki.SetActive(false);
        _maegaki2.SetActive(true);
    }
}
