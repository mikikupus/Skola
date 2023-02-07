using System.Collections;
using UnityEngine;
public class Weapon : MonoBehaviour
{
    public bool singleFire = false;
    public float fireRate = 0.1f;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public int BulletsMax = 30;
    public float ReloadTime = 1.5f;
    public float Damage = 15;

    [HideInInspector]
    public WeaponManager manager;

    float nextFireTime = 0;
    bool canFire = true;
    public int Bullets = 0;
    AudioSource audioSource;

    void Start()
    {
        Bullets = BulletsMax;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && singleFire) Fire();
        if (Input.GetMouseButton(0) && !singleFire) Fire();
        if (Input.GetKeyDown(KeyCode.R) && canFire) StartCoroutine(Reload());
    }

    void Fire()
    {
        if (canFire)
        {
            if (Time.time > nextFireTime)
            {
                nextFireTime = Time.time + fireRate;

                if (Bullets > 0)
                {
                    Vector3 firePointPointerPosition = manager.playerCamera.transform.position + manager.playerCamera.transform.forward * 100;
                    RaycastHit hit;
                    if (Physics.Raycast(manager.playerCamera.transform.position, manager.playerCamera.transform.forward, out hit, 100))
                    {
                        firePointPointerPosition = hit.point;
                    }
                    firePoint.LookAt(firePointPointerPosition);
                    //Fire
                    GameObject bulletObject = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                    Bullet bullet = bulletObject.GetComponent<Bullet>();
                    bullet.SetDamage(Damage);

                    Bullets--;
                }
                else StartCoroutine(Reload());
            }
        }
    }

    IEnumerator Reload()
    {
        canFire = false;
        yield return new WaitForSeconds(ReloadTime);
        Bullets = BulletsMax;
        canFire = true;
    }
    public void ActivateWeapon(bool activate)
    {
        StopAllCoroutines();
        canFire = true;
        gameObject.SetActive(activate);
    }
}