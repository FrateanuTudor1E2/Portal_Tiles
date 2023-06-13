using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    [SerializeField] private AudioSource dieSoundEffect;
    [SerializeField] private AudioSource spawnSoundEffect;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }

    }
    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        dieSoundEffect.Play();
        anim.SetTrigger("death");
        DeleteObjectsWithTag("BluePortal");
        DeleteObjectsWithTag("OrangePortal");
    }
    private void DeleteObjectsWithTag(string tag)
    {
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag(tag);
        foreach (GameObject obj in objectsWithTag)
        {
            Destroy(obj);
        }
    }
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        spawnSoundEffect.Play();
    }
}
