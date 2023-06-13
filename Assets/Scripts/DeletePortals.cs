using UnityEngine;

public class DeletePortals : MonoBehaviour
{
    [SerializeField] private AudioSource deleteSoundEffect;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            DeleteObjectsWithTag("BluePortal");
            DeleteObjectsWithTag("OrangePortal");
        }
    }

    private void DeleteObjectsWithTag(string tag)
    {
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag(tag);
        foreach (GameObject obj in objectsWithTag)
        {
            deleteSoundEffect.Play();
              Destroy(obj);
        }
    }
}
