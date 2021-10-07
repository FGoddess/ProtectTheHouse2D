using UnityEngine;

public class ProgressBar : Bar
{
    [SerializeField] private EnemySpawner _spawner;

    private void OnEnable()
    {
        _spawner.EnemyCountChanged += OnValueChanged;
        Slider.value = 1;
    }

    private void OnDisable()
    {
        _spawner.EnemyCountChanged -= OnValueChanged;
    }
}
