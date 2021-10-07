using UnityEngine;

[CreateAssetMenu(fileName = "Wave", menuName = "Create wave", order = 51)]
public class Wave : ScriptableObject
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private float _delay;
    [SerializeField] private int _count;

    public GameObject EnemyPrefab => _enemyPrefab;
    public float Delay => _delay;
    public int Count => _count;
}
