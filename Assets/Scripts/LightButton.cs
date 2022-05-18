using UnityEngine;

public class LightButton : MonoBehaviour
{
    [Header("Audio Properties")]
    [SerializeField] private AudioClip _switchOnClip;
    [SerializeField] private AudioSource _audioSource;

    [SerializeField] private GameObject[] _lights;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag(MyTags.PlayerTag))
        {
            _audioSource.PlayOneShot(_switchOnClip);

            for (int i = 0; i < _lights.Length; i++)
                _lights[i].SetActive(true);
        }
    }
}