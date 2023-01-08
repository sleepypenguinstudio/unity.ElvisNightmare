using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public GameObject DamageEffect;
    public int DamageAmount = 40;
    private void OnTriggerEnter(Collider other)
    {
        //enemy attack
        if (other.tag == "Enemy")
        {
            Instantiate(DamageEffect, transform.position, DamageEffect.transform.rotation);
            other.GetComponent<Enemy>().TakeDamage(DamageAmount);
            Destroy(gameObject);
        }
    }
}
