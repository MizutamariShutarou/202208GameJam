using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField, Tooltip("�J�ڂ���V�[����")] string _nextSceneName;

    static public SceneChanger Instance = new SceneChanger();
    public void ChangeScene()
   {
        SceneManager.LoadScene(_nextSceneName);
   }
}
