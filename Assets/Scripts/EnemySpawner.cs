using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<Wave> _waves;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Player _player;

    private Wave _currentWave;
    private float _timeAfterLastSpawn;
    private int _currentWaveNumber = 0;
    private int _enemiesSpawned;

    public event UnityAction AllWavesSpawned;
    public event UnityAction<int, int> EnemyCountChanged;

    private void Start()
    {
        SetWave(_currentWaveNumber);
    }

    private void Update()
    {
        if (_currentWave == null)
        {
            return;
        }

        _timeAfterLastSpawn += Time.deltaTime;

        if (_timeAfterLastSpawn >= _currentWave.Delay)
        {
            InstantiateEnemy();
            _enemiesSpawned++;
            _timeAfterLastSpawn = 0;
            EnemyCountChanged?.Invoke(_enemiesSpawned, _currentWave.Count);
        }

        if(_currentWave.Count <= _enemiesSpawned)
        {
            if(_waves.Count > _currentWaveNumber + 1)
            {
                AllWavesSpawned?.Invoke();
            }
            _currentWave = null;
        }
    }

    private void InstantiateEnemy()
    {
        Enemy enemy = Instantiate(_currentWave.EnemyPrefab, _spawnPoint.position, Quaternion.identity, _spawnPoint).GetComponent<Enemy>();
        enemy.Init(_player);
        enemy.Died += OnEnemyDeath;
    }

    private void SetWave(int index)
    {
        _currentWave = _waves[index];
        EnemyCountChanged?.Invoke(0, 1);
    }

    public void SpawnNextWave()
    {
        SetWave(++_currentWaveNumber);
        _enemiesSpawned = 0;
    }

    private void OnEnemyDeath(Enemy enemy)
    {
        enemy.Died -= OnEnemyDeath;

        _player.AddMoney(enemy.Reward);
    }
}
