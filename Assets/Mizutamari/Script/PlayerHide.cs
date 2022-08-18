using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHide : MonoBehaviour
{
    /// <summary> ‰B‚ê‚Ä‚¢‚é‚Étrue </summary>
    bool _isHided;
    Rigidbody2D _rb2d;
    SpriteRenderer _sr;
    public bool IsHided
    {
        get { return _isHided; }
    }
    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Hide(_isHided);
        }
    }
    /// <summary>
    /// ‰B‚ê‚éˆ—
    /// </summary>
    /// <param name="flag"></param>
    void Hide(bool flag)
    {
        _isHided = !flag;
        _sr.enabled = flag;
        _rb2d.simulated = flag;
    }
}
