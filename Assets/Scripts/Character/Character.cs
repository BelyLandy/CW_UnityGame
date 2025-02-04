using UnityEngine;
using System.Collections.Generic;

// Базовый класс Character
public class Character : MonoBehaviour
{
    private int _hp;
    private int _coins;
    private List<GameObject> _inventory;

    public int MaxHP { get; protected set; } = 50;
    public int InventorySize { get; protected set; } = 10;

    public int HP => _hp;
    public int Coins => _coins;
    public IReadOnlyList<GameObject> Inventory => _inventory.AsReadOnly();

    protected virtual void Awake()
    {
        _hp = MaxHP;
        _coins = 0;
        _inventory = new List<GameObject>(InventorySize);
    }

    public void TakeDamage(int damage) => _hp = Mathf.Max(_hp - damage, 0);

    public void Heal(int amount) => _hp = Mathf.Min(_hp + amount, MaxHP);

    public void AddCoins(int amount) => _coins += Mathf.Max(amount, 0);

    public bool SpendCoins(int amount)
    {
        if (amount > 0 && _coins >= amount)
        {
            _coins -= amount;
            return true;
        }
        return false;
    }

    public bool AddToInventory(GameObject item)
    {
        if (item != null && _inventory.Count < InventorySize)
        {
            _inventory.Add(item);
            return true;
        }
        return false;
    }

    public bool RemoveFromInventory(GameObject item) => _inventory.Remove(item);
}