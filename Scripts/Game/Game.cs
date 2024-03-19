using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Beetle _beetle;
    [SerializeField] private EnemyPool _enemyPool;
    [SerializeField] private BulletPool _bulletPool;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private EndScreen _endScreen;

    private void OnEnable()
    {
        _startScreen.PerformButtonClick += OnPerformButtonClick;
        _endScreen.RestartButtonClick += OnRestartButtonClick;
        _beetle.Died += OnGameOver;
    }

    private void OnDisable()
    {
        _startScreen.PerformButtonClick -= OnPerformButtonClick;
        _endScreen.RestartButtonClick -= OnRestartButtonClick;
        _beetle.Died -= OnGameOver;
    }

    private void Start()
    {
        Time.timeScale = 0;

        _startScreen.Open();
    }

    private void OnPerformButtonClick()
    {
        _startScreen.Close();

        StartGame();
    }

    private void OnRestartButtonClick()
    {
        _endScreen.Close();
        _enemyPool.ResetSetOfEnemies();
        _bulletPool.ResetSetOfCartridges();

        StartGame();
    }

    private void StartGame()
    {
        Time.timeScale = 1;

        _beetle.ResetPlayer();
    }

    private void OnGameOver()
    {
        Time.timeScale = 0;
        
        _endScreen.Open();
    }
}