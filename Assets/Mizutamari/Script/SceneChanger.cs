using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField, Tooltip("�J�ڂ���V�[����")] string _nextSceneName;
   public void Changescene()
   {
        SceneManager.LoadScene(_nextSceneName);
   }
}
