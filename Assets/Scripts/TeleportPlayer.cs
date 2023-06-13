using System.Collections;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    public float teleportCooldown = 1f;
    private bool canTeleport = true;
    [SerializeField] private AudioSource teleportSoundEffect;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (canTeleport)
        {
            if (collision.CompareTag("BluePortal"))
            {
                GameObject orangePortal = GameObject.FindGameObjectWithTag("OrangePortal");
                if (orangePortal != null)
                {
                    StartCoroutine(TeleportCoroutine(orangePortal.transform));
                }
            }
            else if (collision.CompareTag("OrangePortal"))
            {
                GameObject bluePortal = GameObject.FindGameObjectWithTag("BluePortal");
                if (bluePortal != null)
                {
                    StartCoroutine(TeleportCoroutine(bluePortal.transform));
                }
            }
        }
    }

    private IEnumerator TeleportCoroutine(Transform destination)
    {
        canTeleport = false;
        teleportSoundEffect.Play();
        // Check if the destination portal is rotated
        float rotationZ = destination.eulerAngles.z;

        // Determine the spawn offset based on the rotation
        Vector3 spawnOffset = Vector3.zero;
        if (rotationZ == -90f)
        {
            spawnOffset = Vector3.down;
        }
        else if (rotationZ == 90f)
        {
            spawnOffset = Vector3.up;
        }

        // Teleport the player to the destination
        transform.position = destination.position + spawnOffset;

        yield return new WaitForSeconds(teleportCooldown);

        canTeleport = true;
    }
}
