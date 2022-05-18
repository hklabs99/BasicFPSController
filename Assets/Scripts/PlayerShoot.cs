using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private float _range = 100f;
    [Space]
    [SerializeField] private Camera _cam;
    [SerializeField] private LayerMask _playerLayer;
    [Space, Header("Audio Properties")]
    [SerializeField] private AudioClip _gunShot;
    [SerializeField] private AudioClip _enemyDie;
    [SerializeField] private AudioSource _audioSource;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Shoot();
    }

    private void Shoot()
    {        
        RaycastHit hit;
        if (PlayerController.Ammo > 0)
        {
            if (Physics.Raycast(_cam.transform.position, _cam.transform.forward, out hit, _range, _playerLayer))
            {
                _audioSource.PlayOneShot(_gunShot);

                PlayerController.ReduceAmmo();

                EnemyAI enemy = hit.transform.GetComponent<EnemyAI>();
                enemy.EnemyDie();
                _audioSource.PlayOneShot(_enemyDie);
            }
        }
    }
}