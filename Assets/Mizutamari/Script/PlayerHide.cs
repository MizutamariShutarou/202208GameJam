using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHide : MonoBehaviour
{
    /// <summary> âBÇÍÇƒÇ¢ÇÈéûÇ…true </summary>
    bool _isHided;
    Rigidbody2D _rb2d;
    SpriteRenderer _sr;
    bool _canHideFlag;
    public bool IsHided
    {
        get { return _isHided; }
        set { _isHided = value; }
    }
    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1) && _canHideFlag)
        {
            //gameObject.transform.localScale = new Vector3(0, 0, 0);
            Hide(false);
        }
        if(Input.GetMouseButtonDown(1) && !_canHideFlag)
        {
            //gameObject.transform.localScale = new Vector3(1, 1, 1);
            Hide(true);
        }
    }
    /// <summary>
    /// âBÇÍÇÈèàóù
    /// </summary>
    /// <param name="flag"></param>
    void Hide(bool flag)
    {
        _isHided = !flag;
        _sr.enabled = flag;
        _rb2d.simulated = flag;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("HideObject"))
        {
            _canHideFlag = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("HideObject"))
        {
            _canHideFlag = false;
        }
    }
}
