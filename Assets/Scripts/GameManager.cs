using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool isGameOver = false;
    public bool isAnotherControllerOn = true;
    [SerializeField] Camera normalCamera;
    [SerializeField] GameObject cinemachineCamera;
    [SerializeField] GameObject joystic;

    public Transform player;

    [SerializeField] GameObject _loseWindow;
    Timer _timer;


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        _timer = GetComponent<Timer>();
        StartCoroutine(JoysticOnOff());
    }
    public void GameOver()
    {
        isGameOver = true;
        _timer.PrintTime();
        _timer.ChekRecord();
        _loseWindow.SetActive(true);
    }
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
     public void SwitchController()
    {
        isAnotherControllerOn = !isAnotherControllerOn;
        if (normalCamera.enabled)
        {
            cinemachineCamera.SetActive(true);
        }
        else
        {
            cinemachineCamera.SetActive(false);
        }
    }
    IEnumerator JoysticOnOff()
    {
        yield return new WaitForSeconds(0.5f);
        if (!DataBox.Instance.isPC)
        {
            joystic.SetActive(true);
        }
    }
}
