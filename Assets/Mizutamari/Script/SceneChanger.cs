using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField, Tooltip("‘JˆÚ‚·‚éƒV[ƒ“–¼")] string _nextSceneName;

    static public SceneChanger Instance = new SceneChanger();
    public void ChangeScene()
   {
        SceneManager.LoadScene(_nextSceneName);
   }
}
