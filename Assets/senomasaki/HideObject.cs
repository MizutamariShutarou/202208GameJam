using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideObject : MonoBehaviour
{
    bool _canHideFlag;

    public bool Flag
    {
        get { return _canHideFlag; }
        set { _canHideFlag = value; }
    }


    // Start is called before the first frame update

    private void Start()
    {
        _canHideFlag = false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _canHideFlag = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        _canHideFlag = false;
    }
}
