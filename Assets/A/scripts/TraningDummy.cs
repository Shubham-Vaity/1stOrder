using UnityEngine;

public class TraningDummy : MonoBehaviour, IDamage
{
    public void applyDamage(float damage)
    {
        Debug.Log("Damage deald "+damage);
    }

}
