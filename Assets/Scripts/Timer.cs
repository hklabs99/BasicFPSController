using System;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float _currentTime;

    [SerializeField] private int _startMinutes;
    [SerializeField] private TextMeshProUGUI _currentTimeText;

    // Start is called before the first frame update
    void Start() => _currentTime = _startMinutes * 60;

    // Update is called once per frame
    void Update() => GameTimer();

    private void GameTimer()
    {
        _currentTime += Time.deltaTime;

        TimeSpan time = TimeSpan.FromSeconds(_currentTime);
        _currentTimeText.text = time.Minutes.ToString() + ":" + time.Seconds.ToString();
    }
}