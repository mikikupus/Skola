using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public Camera playerCamera;
    public Weapon primary;
    public Weapon secondary;

    [HideInInspector]
    public Weapon selectedWeapon;
    void Start()
    {
        primary.ActivateWeapon(true);
        secondary.ActivateWeapon(false);
        selectedWeapon = primary;
        primary.manager = this;
        secondary.manager = this;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            primary.ActivateWeapon(false);
            secondary.ActivateWeapon(true);
            selectedWeapon = secondary;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            primary.ActivateWeapon(true);
            secondary.ActivateWeapon(false);
            selectedWeapon = primary;
        }
    }
}