using UnityEngine;


[CreateAssetMenu(fileName = "NewItemData", menuName = "Inventory/Weapons/Weapon_data")]
public class WeaponData:ScriptableObject
{

    public EPlayerWeaponType weponType;

    public float damage;
    public float Knockback;

    public float attackRadius;
    public float attackDistance;

    public float attackCooldown;

    //public Vector2 direction;
}
