using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextWaveButton : MonoBehaviour
{
    [SerializeField] private EnemySpawner _spawner;
    [SerializeField] private Button _nextWaveButton;

    private void OnEnable()
    {
        _spawner.AllWavesSpawned += AllWavesSpawned;
        _nextWaveButton.onClick.AddListener(OnNextWaveSpawned);
    }

    private void OnDisable()
    {
        _spawner.AllWavesSpawned -= AllWavesSpawned;
        _nextWaveButton.onClick.RemoveListener(OnNextWaveSpawned);
    }

    private void AllWavesSpawned()
    {
        _nextWaveButton.gameObject.SetActive(true);
    }

    public void OnNextWaveSpawned()
    {
        _spawner.SpawnNextWave();
        _nextWaveButton.gameObject.SetActive(false);
    }
}
