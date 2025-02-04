using System;
using UnityEngine;

public class ColliderBaseAttack : MonoBehaviour
{
    public event Action<Collider, bool> OnBaseAttack;

    private void OnTriggerEnter(Collider other)
    {
        OnBaseAttack?.Invoke(other, true);

        Debug.Log("Entered " + other.name);
    }

    private void OnTriggerExit(Collider other)
    {
        OnBaseAttack?.Invoke(other, false);

        Debug.Log("Exited " + other.name);
    }
}