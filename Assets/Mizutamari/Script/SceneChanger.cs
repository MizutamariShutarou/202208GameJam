using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField, Tooltip("‘JˆÚ‚·‚éƒV[ƒ“–¼")] string _nextSceneName;
   public void Changescene()
   {
        SceneManager.LoadScene(_nextSceneName);
   }
}
