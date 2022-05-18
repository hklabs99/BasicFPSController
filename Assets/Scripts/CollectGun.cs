using UnityEngine;

public class CollectGun : PickUp
{
    [SerializeField] private float _rotationSpeed;

    public static bool GunCollected
    {
        get;
        private set;
    }

    private void OnTriggerEnter(Collider other)
    {
        Collectable(other);
        GunCollected = true;
    }

    private void Update()
    {
        float realRotation = _rotationSpeed * Time.deltaTime;
        transform.Rotate(0, realRotation, 0);
    }
}