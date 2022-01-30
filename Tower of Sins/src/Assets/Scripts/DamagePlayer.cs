using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    [SerializeField] private int _damage;
    public AudioSource AudioDamage;
    public AudioClip AudioPlayerDamage;
    
    private void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Player>().HP -= _damage;
            AudioDamage.PlayOneShot(AudioPlayerDamage);
        }
    }
}
