using System.Collections;
using UnityEngine;

public class OruzijeManager : MonoBehaviour
{
    public Camera playerCamera;
    public Oruzije primary;
    public Oruzije secondary;

    public Oruzije selected;

    void Start()
    {
        primary.ActivateWeapon(true);
        secondary.ActivateWeapon(false);
        selected = primary;
        primary.manager = this;
        secondary.manager = this;
    }

    void Update()
    {
        if (Input.GetKeyDown("2"))
        {
            primary.ActivateWeapon(false);
            secondary.ActivateWeapon(true);
            selected = secondary;
        }

        if (Input.GetKeyDown("1"))
        {
            primary.ActivateWeapon(true);
            secondary.ActivateWeapon(false);
            selected = primary;
        }
    }  
}
