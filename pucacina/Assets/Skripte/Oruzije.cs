using System.Collections;
using UnityEngine;

public class Oruzije : MonoBehaviour
{
    public bool single = false;
    public float firerate = 0.1f;
    public GameObject bulletp;
    public Transform firepoint;
    public int bulletsPoMagazinu = 30;
    public float vremeZaReload = 1.5f;
    public float Damage = 15;
    [HideInInspector]
    public OruzijeManager manager;

    float nextFireTime = 0;
    bool canFire = true;
    public int bulletsPoMagazinuDefault = 0;

    void Start()
    {
        bulletsPoMagazinuDefault = bulletsPoMagazinu;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && single)
        {
            Fire();
        }
        if (Input.GetMouseButton(0) && !single)
        {
            Fire();
        }
        if (Input.GetKeyDown(KeyCode.R) && canFire)
        {
            StartCoroutine(Reload());
        }
    }

    void Fire()
    {
        if (canFire)
        {
            if (Time.time > nextFireTime)
            {
                nextFireTime = Time.time + firerate;

                if (bulletsPoMagazinu > 0)
                {
                    Vector3 firepointPozicija = manager.playerCamera.transform.position + manager.playerCamera.transform.forward * 100;
                    RaycastHit hit;
                    if (Physics.Raycast(manager.playerCamera.transform.position, manager.playerCamera.transform.forward, out hit, 100))
                    {
                        firepointPozicija = hit.point;
                    }
                    firepoint.LookAt(firepointPozicija);
                    GameObject bulletObject = Instantiate(bulletp, firepoint.position, firepoint.rotation);
                    Metak bullet = bulletObject.GetComponent<Metak>();
                    bullet.SetDamage(Damage);

                    bulletsPoMagazinu--;
                }
                if (bulletsPoMagazinu < 0)
                {
                    StartCoroutine(Reload());
                }
            }
        }
    }

    IEnumerator Reload()
    {
        canFire = false;
        yield return new WaitForSeconds(vremeZaReload);
        bulletsPoMagazinu = bulletsPoMagazinuDefault;
        canFire = true;
    }

    public void ActivateWeapon(bool activate)
    {
        StopAllCoroutines();
        canFire = true;
        gameObject.SetActive(activate);
    }
}
