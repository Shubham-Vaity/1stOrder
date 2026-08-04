using UnityEngine;

public class TraningDummy : MonoBehaviour,I_Interact
{
    public void interact(E_Player_Wepon wepon, float damage)
    {
        Debug.Log("Damage deald "+damage);
    }

}
