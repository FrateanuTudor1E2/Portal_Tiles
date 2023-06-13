using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
    private Transform m_transform;


    // Start is called before the first frame update
    private void Start()
    {
        m_transform = this.transform;
    }

    private void LAMouse()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint
           (Input.mousePosition) - m_transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) *
            Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle , Vector3.forward);
        m_transform.rotation = rotation;

    }
    void Update()
    {
        LAMouse();
    }
}
