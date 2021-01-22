
using UnityEngine;

public class DieSpace : MonoBehaviour
{

    public GameObject respawn;
    public AudioSource mySu;
    public AudioClip lose;

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.tag == "Player")
        {
            mySu.PlayOneShot(lose);
            other.transform.position = respawn.transform.position;
        }
    }
}
