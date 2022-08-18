using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D  _rb;
    [SerializeField, Tooltip("�ړ����x")]
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        //float v = Input.GetAxis("Vertical");

        Vector2 direction = new Vector2(h, 0).normalized;

        // �ړ���������ƃX�s�[�h���� 
        GetComponent<Rigidbody2D>().velocity = direction * speed;
    }
}
