using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageMonter : MonoBehaviour
{
    public AudioSource AudioDamage;
    public AudioClip AudioGoblin;
    public AudioClip AudioSkeleton;
    public AudioClip AudioGolem;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Goblin>())
        {
            other.GetComponent<Goblin>().HP -= 10;
            AudioDamage.PlayOneShot(AudioGoblin);
        }
        else if (other.GetComponent<Skeleton>())
        {
            other.GetComponent<Skeleton>().HP -= 10;
            AudioDamage.PlayOneShot(AudioSkeleton);
        }
        else if (other.GetComponent<Golem>())
        {
            other.GetComponent<Golem>().HP -= 10;
            AudioDamage.PlayOneShot(AudioGolem);
        }
    }
}
