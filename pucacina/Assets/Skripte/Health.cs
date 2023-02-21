using UnityEngine;

public class Health : MonoBehaviour, IEntity
{
    public float HP = 100;
    public Kretanje kontroler;
    public OruzijeManager manager;

    public void ApplyDamage(float points)
    {
        HP -= points;

        if (HP<=0)
        {
            kontroler.canMove = false;
            HP = 0;
        }
    }
}
