using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Goblin : MonoBehaviour
{
    [SerializeField] private Transform _target;
    
    private Animator _animatorGoblin;
    private NavMeshAgent _agentGoblin;
    private float _distance;

    [Header("Goblin")]
    public int HP = 10;
    
    void Start()
    {
        _animatorGoblin = GetComponent<Animator>();
        _agentGoblin = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        _distance = Vector3.Distance(transform.position, _target.position);
        if (_distance > 15)
        {
            _agentGoblin.enabled = false;
            _animatorGoblin.SetFloat("Speed", 0);
        }
        else if (_distance <= 15)
        {
            _agentGoblin.enabled = true;
            _agentGoblin.SetDestination(_target.position);
            _animatorGoblin.SetFloat("Speed", 1);
        }

        if (_distance <= 1.5f)
        {
            _animatorGoblin.SetTrigger("Attake");
        }
        if(HP <= 0) Destroy(gameObject);
    }
}
