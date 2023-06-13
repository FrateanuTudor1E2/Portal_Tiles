using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyOnCollsion : MonoBehaviour
{
    public GameObject Bray;
    public GameObject Oray;
    [SerializeField] private AudioSource spawnPortalSoundEffect;
    // Start is called before the first frame update
    void Start()
    {
        Bray = GameObject.FindWithTag("BLRay");
        Oray = GameObject.FindWithTag("ORRay");
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("BLRay"))

        {
            spawnPortalSoundEffect.Play();
            Destroy(GameObject.FindGameObjectWithTag("BLRay"));
        }
        if (collision.CompareTag("ORRay"))

        {
            spawnPortalSoundEffect.Play();
            Destroy(GameObject.FindGameObjectWithTag("ORRay"));
        }
    }
    
    
}