using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �ꎞ��~�E�ĊJ�𐧌䂷��B
/// </summary>
public class PauseManager : MonoBehaviour, IPause
{
    /// <summary>
    /// true �̎��͈ꎞ��~
    /// </summary>
    bool _isPause = false;
    public bool IsPause => _isPause;

    static public PauseManager Instance = new PauseManager();
    /// <summary>
    ///Pause���ɕ\���������
    /// </summary>
    [SerializeField] Text _pauseText;
    [SerializeField] string _pauseMessage = "Pause";
    [SerializeField] Animator _pauseAnim;
    [SerializeField, Tooltip("�Q�[���I���{�^��")] Button _exitButton;
    [SerializeField] GameObject _panel;

    private void Start()
    {
        _pauseText.text = "";
        _panel.SetActive(false);
        _exitButton.gameObject.SetActive(false);
    }
    void Update()
    {
        // ESC �L�[�ňꎞ��~�E�ĊJ��؂�ւ���
        if (Input.GetButtonDown("Cancel"))
        {
            PauseResume();
        }
    }

    /// <summary>
    /// �ꎞ��~�E�ĊJ��؂�ւ���
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
        // �A�j���[�V�������Đ����ă��b�Z�[�W��\������
        _panel.gameObject.SetActive(true);
        _pauseText.text = _pauseMessage;
        _pauseAnim?.Play("Blink");
        _exitButton.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    void IPause.Resume()
    {
        // �\��������
        _panel.gameObject.SetActive(false);
        _pauseText.text = "";
        _pauseAnim?.Play("Pause");
        _exitButton.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}