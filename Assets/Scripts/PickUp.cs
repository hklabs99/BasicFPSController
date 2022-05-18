using UnityEngine;

public abstract class PickUp : MonoBehaviour
{
    protected void Collectable(Collider other)
    {
        if (other.CompareTag(MyTags.PlayerTag))
            gameObject.SetActive(false);
    }
}