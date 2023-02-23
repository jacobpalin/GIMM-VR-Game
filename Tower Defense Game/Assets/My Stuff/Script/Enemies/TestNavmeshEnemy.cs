using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TestNavmeshEnemy : MonoBehaviour
{
    public int health;
    public int currentHealth;
    private Transform moveToThisObject;
    public float attackRange;
    public float attackCooldown;
    private float attackAgain;

    public int damage;

    public LayerMask destroyables;

    private NavMeshAgent navMeshAgent;

    private Vector3 previousPosition;
    private float currentSpeed;

    public AudioSource audioSource;
    public float volume;

    // Start is called before the first frame update
    void Awake()
    {
        currentHealth = health;

        moveToThisObject = GameObject.FindGameObjectWithTag("TestDefendObject").transform;

        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        navMeshAgent.destination = moveToThisObject.position;
        //Debug.Log(currentHealth);
        if (currentHealth <= 0)
        {
            Dead();
            //Debug.Log("they should be dead");
        }

        Vector3 moving = transform.position - previousPosition;
        currentSpeed = moving.magnitude / Time.deltaTime;
        previousPosition = transform.position;

        if (currentSpeed == 0 && attackAgain < Time.time)
        {
            Collider[] objectsToHit = Physics.OverlapSphere(this.transform.position, attackRange, destroyables);
            foreach (Collider destroyableObject in objectsToHit)
            {
                OnTriggerEnter(destroyableObject);
            }
            attackAgain = Time.time + attackCooldown;
        }
    }

    private void Dead()
    {
        Destroy(gameObject, 1f);
    }

    public void LoseHealth(int dmg)
    {
        audioSource.PlayOneShot(audioSource.clip, volume);
        currentHealth -= dmg;
        //Debug.Log("health should be " + currentHealth);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("nav attacking wall");
        if (other.TryGetComponent(out DefendObject health))
        {
            health.LoseHealth(damage);
            //Debug.Log("nav attacking defend");
        }
        if (other.TryGetComponent(out Wall wallHealth))
        {
            wallHealth.LoseHealth(damage);
            //Debug.Log("nav attacking wall");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(this.transform.position, attackRange);
    }
}