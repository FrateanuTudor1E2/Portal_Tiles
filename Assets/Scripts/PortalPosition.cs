using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalPosition : MonoBehaviour
{
    private Transform portalTransform;

    public Vector3 GetPortalPosition()
    {
        if (portalTransform != null)
        {
            return portalTransform.position;
        }
        else
        {
            Debug.LogError("Portal transform is not assigned.");
            return Vector3.zero;
        }
    }

    public void SetPortalTransform(Transform transform)
    {
        portalTransform = transform;
    }
}
