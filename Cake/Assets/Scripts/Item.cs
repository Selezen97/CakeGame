using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [SerializeField] private TMP_Text _label;
    [SerializeField] private TMP_Text _price;
    [SerializeField] private TMP_Text _profit;
    [SerializeField] private Image _icon;
    [SerializeField] private Button _sellButton;
    private CakeShopItem _cakeItem;
    public event UnityAction<CakeShopItem, Item> SellButtonClick;

    private void OnEnable()
    {
        _sellButton.onClick.AddListener(CheckCakeState);
        _sellButton.onClick.AddListener(OnSellButtonClick);
    }

    private void OnDisable()
    {
        _sellButton.onClick.RemoveListener(CheckCakeState);
        _sellButton.onClick.RemoveListener(OnSellButtonClick);
    }

    private void OnSellButtonClick()
    {
        SellButtonClick?.Invoke(_cakeItem,this);
    }

    private void CheckCakeState()
    {
        if (_cakeItem.IsBuy)
        {
            _sellButton.interactable = false;
            _label.text = "Sold!";
        }
    }

    public void SetCake(CakeShopItem cakeItem)
    {
        _cakeItem = cakeItem;
        RenderCake(cakeItem);
    }

    private void RenderCake(CakeShopItem cakeItem)
    {
        _label.text = cakeItem.Label;
        _price.text = cakeItem.Price.ToString();
        _profit.text = cakeItem.CakeProfit.ToString();
        _icon.sprite = cakeItem.Icon;
    }
}
