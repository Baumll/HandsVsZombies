using System.Collections;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    [SerializeField] private GameObject explosion;
    public AudioSource explosionSound;

    public void OnCollisionEnter(Collision collision)
    {
        GameObject newExplosion = Instantiate(explosion, transform.position, transform.rotation);
        StartCoroutine(DestroyAfterSound());
    }

    public void OnTriggerEnter(Collider other)
    {
        GameObject newExplosion = Instantiate(explosion, transform.position, transform.rotation);
        StartCoroutine(DestroyAfterSound());
    }

    IEnumerator DestroyAfterSound()
    {
        explosionSound.transform.parent = null;

        explosionSound.Play();
        
        Destroy(gameObject);

        //Warten bevor Audiosource gelöscht wird, sodass der Sound zuende spielt
        yield return new WaitForSeconds(explosionSound.clip.length);
        
        Destroy(explosionSound.gameObject);
    }
}