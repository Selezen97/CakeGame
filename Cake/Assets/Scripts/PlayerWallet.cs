using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerWallet : MonoBehaviour
{
    private int _bakedCakes;
    public int BakedCakes => _bakedCakes;
    public event UnityAction<int> CakeBalanceChanged;

    public void AddCakeProfit(int amount)
    {
        _bakedCakes += amount;
        CakeBalanceChanged?.Invoke(_bakedCakes);
    }

    public void WithdrawCakes(int amount)
    {
        _bakedCakes -= amount;
        CakeBalanceChanged?.Invoke(_bakedCakes);
    }
}
