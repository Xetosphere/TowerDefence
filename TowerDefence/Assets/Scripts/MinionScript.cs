using UnityEngine;
using System.Collections;

public enum AttackType
{
    Water, Fire, Rock, Lightning, Ice, Wind
};

public class MinionScript : MonoBehaviour {

    // Public

    public int health = 50;
    public int damage = 1;
    public AttackType weakness = AttackType.Fire;
    public AttackType resistance = AttackType.Water;

    // Private


    void Start()
    {
        Debug.Log("Name: " + transform.name + ", Health: " + health + ", Damage: " + damage + ", Weakness: " + weakness + ", Resistance: " + resistance);
    }
}
