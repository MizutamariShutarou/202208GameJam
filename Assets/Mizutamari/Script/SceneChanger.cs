using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField, Tooltip("遷移するシーン名")] string _nextSceneName;

    static public SceneChanger Instance = new SceneChanger();
    public void ChangeScene()
   {
        SceneManager.LoadScene(_nextSceneName);
   }
}
