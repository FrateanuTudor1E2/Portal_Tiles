using System.Collections;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    private GameObject player;
    private bool canTeleport = true;
    private float teleportCooldown = 1f;
    private Transform otherPortalTransform;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && canTeleport)
        {
            //StartCoroutine(StartTeleportation());
        }
    }

    private IEnumerator StartTeleportation()
    {
        canTeleport = false;

        if (otherPortalTransform != null)
        {
            // Get the teleport component of the other portal
            Teleport otherPortalTeleport = otherPortalTransform.GetComponent<Teleport>();

            if (otherPortalTeleport != null && otherPortalTeleport.otherPortalTransform != null)
            {
                // Get the portal position from the teleport component of the other portal
                Vector3 teleportPosition = otherPortalTeleport.otherPortalTransform.position;

                // Teleport the player to the calculated position
                player.transform.position = teleportPosition;

                // Disable teleportation for a short duration to prevent instant teleportation back
                canTeleport = false;
                otherPortalTeleport.canTeleport = false;
                yield return new WaitForSeconds(teleportCooldown);
                canTeleport = true;
                otherPortalTeleport.canTeleport = true;
            }
            else
            {
                Debug.LogWarning("Other portal teleport component or its other portal transform is not assigned.");
            }
        }
        else
        {
            Debug.LogWarning("Other portal transform is not assigned.");
        }
    }

    public void SetOtherPortalTransform(Transform portalTransform)
    {
        otherPortalTransform = portalTransform;
    }
}
