using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private Player _player;
    [SerializeField] private WeaponView _weaponView;
    [SerializeField] private GameObject _itemContainer;

    private void Start()
    {
        foreach(var weapon in _weapons)
        {
            AddItem(weapon);
        }
    }

    private void AddItem(Weapon weapon)
    {
        var view = Instantiate(_weaponView, _itemContainer.transform);
        view.SellButtonClick += OnSellButtonClick;
        view.Render(weapon);
    }

    private void OnSellButtonClick(Weapon weapon, WeaponView view)
    {
        SellWeapon(weapon, view);
    }

    private void SellWeapon(Weapon weapon, WeaponView view)
    {
        if(weapon.Price <= _player.Money)
        {
            _player.BuyWeapon(weapon);
            weapon.Buy();
            view.SellButtonClick -= OnSellButtonClick;
        }
    }

}
