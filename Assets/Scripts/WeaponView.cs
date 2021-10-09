using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class WeaponView : MonoBehaviour
{
    [SerializeField] private TMP_Text _label;
    [SerializeField] private TMP_Text _price;
    [SerializeField] private Image _icon;
    [SerializeField] private Button _buyBttn;

    private Weapon _weapon;

    public event UnityAction<Weapon, WeaponView> SellButtonClick;

    private void OnEnable()
    {
        _buyBttn.onClick.AddListener(OnButtonClick);
        _buyBttn.onClick.AddListener(SellItem);
    }

    private void OnDisable()
    {
        _buyBttn.onClick.RemoveListener(OnButtonClick);
        _buyBttn.onClick.RemoveListener(SellItem);
    }

    private void SellItem()
    {
        if(_weapon.IsBought)
        {
            _buyBttn.interactable = false;
        }
    }

    public void Render(Weapon weapon)
    {
        _weapon = weapon;

        _label.text = weapon.Label;
        _price.text = weapon.Price.ToString();
        _icon.sprite = weapon.Icon;
    }

    private void OnButtonClick()
    {
        SellButtonClick?.Invoke(_weapon, this);
    }
}
