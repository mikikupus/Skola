using System.Collections;
using UnityEngine;

public class Metak : MonoBehaviour
{
    public float metakspeed = 345;
    public float hitForce = 50f;
    public float unistiPosle = 3.5f;
    public LayerMask ignore;

    float trenutnoVreme = 0;
    Vector3 newPos;
    Vector3 oldPos;
    bool hasHit = false;
    float damagePoints;

    IEnumerator Start()

    {
        newPos = transform.position;
        oldPos = newPos;

        while (trenutnoVreme < unistiPosle && !hasHit)
        {
            Vector3 velocity = transform.forward * metakspeed;
            newPos += velocity * Time.deltaTime;
            Vector3 direction = newPos - oldPos;
            float distance = direction.magnitude;
            RaycastHit hit;
            if (Physics.Raycast(oldPos, direction, out hit, distance, ignore))
            {
                if (hit.rigidbody != null)
                {
                    hit.rigidbody.AddForce(direction * hitForce);

                    IEntity npc = hit.transform.GetComponent<IEntity>();
                    if (npc != null)
                    {
                        npc.ApplyDamage(damagePoints);
                    }
                }

                newPos = hit.point;
                StartCoroutine(unistiMetak());
            }
            trenutnoVreme += Time.deltaTime;
            yield return new WaitForFixedUpdate();

            transform.position = newPos;
            oldPos = newPos;
        }
        if (!hasHit)
        {
            StartCoroutine(unistiMetak());
        }
        IEnumerator unistiMetak()
        {
            hasHit = true;
            yield return new WaitForSeconds(0.5f);
            Destroy(gameObject);
        }
        
    }
    public void SetDamage(float points)
    {
        damagePoints = points;
    }
}
