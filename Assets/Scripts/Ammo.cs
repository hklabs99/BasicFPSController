using UnityEngine;

public class Ammo : PickUp
{
    private void OnTriggerEnter(Collider other) => Collectable(other);
}