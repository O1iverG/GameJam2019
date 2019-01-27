using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class SnupuBattle : MonoBehaviour
{
    private float snupuHealth = 40f;
    public AudioClip deathSound;
    AudioSource audioSource;
    Animator animator;
    public GameObject snupu;
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = snupu.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Trap")
        {
            audioSource.PlayOneShot(deathSound, 0.7f);
            animator.SetBool("isDead", true);
            Destroy(collision.gameObject);
            Destroy(this.gameObject, 1);
        }
        if (collision.gameObject.tag == "Goal")
        {
            SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
        }
    }
}
