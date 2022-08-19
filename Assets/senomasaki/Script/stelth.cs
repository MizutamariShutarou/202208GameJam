using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stelth : MonoBehaviour
{
    public GameObject Square;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Square.SetActive(false);
        }
    }
}
