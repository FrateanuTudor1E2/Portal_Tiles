using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootOR : MonoBehaviour
{
    public GameObject ORRay;
    public Transform firePoint;
    public float raySpeed = 50;
    Vector2 lookDirection;
    float lookAngle;
    private void Start()
    {
        firePoint = this.transform;
    }
   

    // Update is called once per frame
    void Update()
    {

        lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        lookDirection = new Vector2(lookDirection.x - transform.position.x, lookDirection.y - transform.position.y);
        lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;

        firePoint.rotation = Quaternion.Euler(0, 0, lookAngle);

        if (Input.GetMouseButtonDown(1))
        {
            GameObject rayClone = Instantiate(ORRay);
            rayClone.transform.position = firePoint.position;
            rayClone.transform.rotation = Quaternion.Euler(0, 0, lookAngle);

            rayClone.GetComponent<Rigidbody2D>().velocity = firePoint.right * raySpeed;
        }
    }
}
