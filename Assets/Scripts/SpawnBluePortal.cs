
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBluePortal : MonoBehaviour
{
    [SerializeField] private GameObject bluePortalPrefab;
    private GameObject bluePortal;
    private GameObject orangePortal;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PortalSurface"))
        {
            DeleteObjectsWithTag("BluePortal");

            Vector2 spawnPosition = collision.transform.position;
            Quaternion spawnRotation = collision.transform.rotation;
     
            SpawnPortal(bluePortalPrefab, spawnPosition, spawnRotation);

            // Check if both portals are spawned
            CheckPortalsSpawned();
        }
    }
    private void DeleteObjectsWithTag(string tag)
    {

      
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag(tag);
        foreach (GameObject obj in objectsWithTag)
        {
            Destroy(obj);
        }
    }
    private void SpawnPortal(GameObject portalPrefab, Vector2 position, Quaternion rotation)
    {
        bluePortal = Instantiate(portalPrefab, position, rotation);//Quaternion.identity
        
        // Get the PortalPosition component of the spawned portal
        PortalPosition portalPosition = bluePortal.GetComponent<PortalPosition>();

        // Assign the portal transform to the Teleport component
        Teleport bluePortalTeleport = bluePortal.GetComponent<Teleport>();
        bluePortalTeleport.SetOtherPortalTransform(portalPosition.transform);
    }

    private void CheckPortalsSpawned()
    {
        if (bluePortal != null && orangePortal != null)
        {
            Teleport bluePortalTeleport = bluePortal.GetComponent<Teleport>();
            Teleport orangePortalTeleport = orangePortal.GetComponent<Teleport>();

            // Update the teleport references of the portals
            bluePortalTeleport.SetOtherPortalTransform(orangePortal.GetComponent<PortalPosition>().transform);
            orangePortalTeleport.SetOtherPortalTransform(bluePortal.GetComponent<PortalPosition>().transform);
        }
    }
}
