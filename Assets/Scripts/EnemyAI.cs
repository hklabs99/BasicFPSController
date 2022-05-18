using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [Header("AI Requirements")]
    [SerializeField] private float _lookRadius = 10f;
    [SerializeField] private Transform _playerTarget;
    [SerializeField] private NavMeshAgent _agent;
    [Space, Header("Audio Properties")]
    [SerializeField] private AudioClip _playerDetectSound;
    [SerializeField] private AudioSource _audioSource;

    private enum EnemyStates
    {
        Idle,
        Chase,
    }

    private EnemyStates _currentEnemyState;

    // Update is called once per frame
    void Update()
    {                
        float distance = Vector3.Distance(_playerTarget.position, transform.position);
        if (distance <= _lookRadius)
            _currentEnemyState = EnemyStates.Chase;

        StateManager(distance);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _lookRadius);
    }

    private void FacePlayer()
    {
        Vector3 dir = (_playerTarget.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(dir.x, 0, dir.y));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    private void StateManager(float distance)
    {
        switch (_currentEnemyState)
        {
            case EnemyStates.Chase:
                ChaseState(distance);
                break;

            default: _currentEnemyState = EnemyStates.Idle;
                break;
        }
    }
    
    private void ChaseState(float distance)
    {
        _audioSource.PlayOneShot(_playerDetectSound);
        _agent.SetDestination(_playerTarget.position);

        if (distance <= _agent.stoppingDistance)
            FacePlayer();
    }

    public void EnemyDie() => Destroy(gameObject);
}