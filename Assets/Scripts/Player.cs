using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private Transform _shootPoint;

    private Weapon _currentWeapon;
    private int _currentWeaponIndex = 0;
    private int _currentHealth;
    private Animator _animator;

    public int Money { get; private set; }

    public event UnityAction<int, int> HealthChanged;
    public event UnityAction<int> MoneyChanged;

    private void Start()
    {
        SelectWeapon(_weapons[_currentWeaponIndex]);
        _currentHealth = _maxHealth;
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            _currentWeapon.Shoot(_shootPoint);
        }
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        HealthChanged?.Invoke(_currentHealth, _maxHealth);

        if (_currentHealth <= 0)
        {
            gameObject.SetActive(false);
            Time.timeScale = 0;
        }
    }

    public void BuyWeapon(Weapon weapon)
    {
        Money -= weapon.Price;
        MoneyChanged?.Invoke(Money);
        _weapons.Add(weapon);
    }

    public void AddMoney(int money)
    {
        Money += money;
        MoneyChanged?.Invoke(Money);
    }

    public void NextWeapon()
    {
        _currentWeaponIndex = _currentWeaponIndex == _weapons.Count - 1 ? 0 : _currentWeaponIndex + 1;
        SelectWeapon(_weapons[_currentWeaponIndex]);
    }

    public void PreviousWeapon()
    {
        _currentWeaponIndex = _currentWeaponIndex == 0 ? _weapons.Count - 1 : _currentWeaponIndex - 1;
        SelectWeapon(_weapons[_currentWeaponIndex]);
    }

    public void SelectWeapon(Weapon weapon)
    {
        _currentWeapon = weapon;
    }
}
