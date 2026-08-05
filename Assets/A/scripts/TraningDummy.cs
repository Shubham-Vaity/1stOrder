using UnityEngine;

public class TraningDummy : MonoBehaviour, IDamageable
{
    public void TakeDamage(SDamageData damage)
    {
        Debug.Log("Damage deald "+damage.amount);
    }

}
