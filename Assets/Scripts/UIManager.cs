using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [Header("Ammo Counter Properties")]
    [SerializeField] private TextMeshProUGUI _ammoCounter;

    [Header("Remaining Ammo Properties")]
    [SerializeField] private TextMeshProUGUI _ammoLeftText;
    [SerializeField] private GameObject _ammoParent;

    [Header("Pause Menu Properties")]
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _pauseText;

    public static bool IsPaused
    {
        get;
        private set;
    }

    private void Awake() => IsPaused = false;

    // Update is called once per frame
    void Update()
    {
        TriggerPause();
        AmmoManager();
        PauseGame();
    }

    private void AmmoManager()
    {
        _ammoCounter.text = "Ammo: " + PlayerController.Ammo.ToString();

        _ammoLeftText.text = "Left: " + _ammoParent.GetComponentsInChildren<Ammo>().GetLength(0);
    }

    private void TriggerPause()
    {
        if (IsPaused)
        {
            _pauseMenu.SetActive(true);
            _pauseText.SetActive(false);
            Time.timeScale = 0;
        }

        else
        {
            Time.timeScale = 1;
            _pauseMenu.SetActive(false);
            _pauseText.SetActive(true);
        }
    }

    private void PauseGame()
    {
        if (Input.GetKey(KeyCode.Escape))
            IsPaused = true;
    }

    #region Pause Menu Button Methods

    public void ResumeGame()
    {
        IsPaused = false;
        _pauseMenu.SetActive(false);
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    public void QuitGame() => Application.Quit();

    #endregion
}