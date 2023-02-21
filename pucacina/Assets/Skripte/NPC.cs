using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Rigidbody))]

public class NPC : MonoBehaviour, IEntity
{
    public float distancanapada = 3f;
    public float brzinakretnje = 4f;
    public GameObject bulletp;
    public float npcHP = 100f;
    public float npcDamage = 5f;
    public float attackrate = 0.5f;
    public Transform firePoint;
    public GameObject NPCMrtavP;
    [HideInInspector]public Transform playerTransform;
    [HideInInspector]public NPCSpawner spawn;
    NavMeshAgent enemy;
    float nextAttackTime;
    Rigidbody r;

    void Start()
    {
        nextAttackTime = 0f;
        enemy = GetComponent<NavMeshAgent>();
        enemy.stoppingDistance = distancanapada;
        enemy.speed = brzinakretnje;
        r = GetComponent<Rigidbody>();
        r.useGravity = false;
        r.isKinematic = true;
    }

    void Update()
    {
        if(enemy.remainingDistance-distancanapada<0.01f)
        {
            if (Time.time>nextAttackTime)
            {
                nextAttackTime = Time.time + attackrate;

                RaycastHit hit;
                if (Physics.Raycast(firePoint.position, firePoint.forward, out hit, distancanapada))
                {
                    if (hit.transform.CompareTag("Player"))
                    {
                        Debug.DrawLine(firePoint.position, firePoint.position + firePoint.forward * distancanapada, Color.cyan);
                        GameObject bulletObject = Instantiate(bulletp, firePoint.position, firePoint.rotation);
                        IEntity player = hit.transform.GetComponent<IEntity>();
                        player.ApplyDamage(npcDamage);
                    }
                }
            }
        }
        enemy.destination = playerTransform.position;

        playerTransform.LookAt(new Vector3(playerTransform.transform.position.x, playerTransform.transform.position.y, playerTransform.transform.position.z));
        r.velocity *= 0.99f;
    }
    public void ApplyDamage(float points)
    {
        npcHP -= points;
        if(npcHP<=0)
        {
            GameObject NPCMrtav = Instantiate(NPCMrtavP, this.transform.position, this.transform.rotation);
            NPCMrtav.GetComponent<Rigidbody>().velocity= (-(playerTransform.position - transform.position).normalized * 8) + new Vector3(0, 5, 0);
            Destroy(NPCMrtav, 10);
            spawn.EnemyEliminated(this);
            Destroy(gameObject);
        }
    }
}
