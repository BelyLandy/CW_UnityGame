using UnityEngine;

public class IlyaMurometz : Character
{
    private int _rage;
    public int MaxRage { get; private set; } = 100;
    public int Rage => _rage;

    protected override void Awake()
    {
        base.Awake();  // Вызов базового конструктора
        _rage = 0;
    }

    // Метод для увеличения rage
    public void AddRage(int amount) => _rage = Mathf.Min(_rage + amount, MaxRage);

    // Метод для использования rage
    public void SpendRage(int amount) => _rage = Mathf.Max(_rage - amount, 0);
}