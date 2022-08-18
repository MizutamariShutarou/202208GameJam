using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 一時停止・再開を制御する。
/// </summary>
public class PauseManager : MonoBehaviour, IPause
{
    /// <summary>
    /// true の時は一時停止
    /// </summary>
    bool _isPause = false;
    public bool IsPause => _isPause;

    static public PauseManager Instance = new PauseManager();
    /// <summary>
    ///Pause中に表示するもの
    /// </summary>
    [SerializeField] Text _pauseText;
    [SerializeField] string _pauseMessage = "Pause";
    [SerializeField] Animator _pauseAnim;
    [SerializeField, Tooltip("ゲーム終了ボタン")] Button _exitButton;
    [SerializeField] GameObject _panel;

    private void Start()
    {
        _pauseText.text = "";
        _panel.SetActive(false);
        _exitButton.gameObject.SetActive(false);
    }
    void Update()
    {
        // ESC キーで一時停止・再開を切り替える
        if (Input.GetButtonDown("Cancel"))
        {
            PauseResume();
        }
    }

    /// <summary>
    /// 一時停止・再開を切り替える
    /// </summary>
    void PauseResume()
    {
        _isPause = !_isPause;

        var objects = FindObjectsOfType<GameObject>();

        foreach (var o in objects)
        {
            IPause i = o.GetComponent<IPause>();

            if (_isPause)
            {
                i?.Pause();
            }
            else
            {
                i?.Resume();
            }
        }
    }
    void IPause.Pause()
    {
        // アニメーションを再生してメッセージを表示する
        _panel.gameObject.SetActive(true);
        _pauseText.text = _pauseMessage;
        _pauseAnim?.Play("Blink");
        _exitButton.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    void IPause.Resume()
    {
        // 表示を消す
        _panel.gameObject.SetActive(false);
        _pauseText.text = "";
        _pauseAnim?.Play("Pause");
        _exitButton.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}