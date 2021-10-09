using TMPro;
using UnityEngine;

public class Balance : MonoBehaviour
{
    [SerializeField] private TMP_Text _balance;
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _balance.text = _player.Money.ToString();
        _player.MoneyChanged += OnMoneyChanged;
    }

    private void OnDisable()
    {
        _player.MoneyChanged -= OnMoneyChanged;
    }

    private void OnMoneyChanged(int money)
    {
        _balance.text = money.ToString();
    }

}
