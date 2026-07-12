using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip walkSound;
    public AudioClip blowSound;
    public AudioClip damageSound;
    public AudioClip flySound;


    public void PlayWalk()
    {
        audioSource.PlayOneShot(walkSound);
    }

    public void PlayBlow()
    {
        audioSource.PlayOneShot(blowSound);
    }

    public void PlayDamage()
    {
        audioSource.PlayOneShot(damageSound);
    }

    public void PlayFly()
    {
        audioSource.PlayOneShot(flySound);
    }
}
