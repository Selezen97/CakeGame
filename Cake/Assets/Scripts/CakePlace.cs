using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class CakePlace : MonoBehaviour
{
    private Cake _cake;
    [SerializeField] private ClickerZone _clickerZone;
    [SerializeField] private CookingProgressBar _cookingProgressBar;
    public event UnityAction<Cake> CakeReadyForCollection;
   // private void Start()
    //{
      //  SetCake(_cake);
    //}
    public void SetCake(Cake cake)
    {
        //if (_cake != null)
          //  RemoveCake(_cake);
        _cake = Instantiate(cake,transform);
        _cake.CakeDone += OnCakeDone;
        _cake.LayerCookingProgress += _cookingProgressBar.OnLayerCookingProgress;
        _clickerZone.Click += _cake.OnClick;
    }

    public void RemoveCake(Cake cake)
    {
        _cake.CakeDone -= OnCakeDone;
        _cake.LayerCookingProgress -= _cookingProgressBar.OnLayerCookingProgress;
        _clickerZone.Click -= _cake.OnClick;
        Destroy(cake);
    }

    private void OnCakeDone()
    {
        CakeReadyForCollection?.Invoke(_cake);
    }
}
