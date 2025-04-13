using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePos;
    public GameObject muzzle;

    public float TimeBtwFire = 0.2f;
    public float bulletForce;

    private float timeBtwFire;
    void Update()
    {
        RotateGun();
        timeBtwFire -= Time.deltaTime;
        if (Input.GetMouseButton(0) && timeBtwFire < 0)
        {
            FireBullet();
        }
    }

    void RotateGun()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;

        Vector2 lookDir = mousePos - transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;

        Quaternion rotation = Quaternion.Euler(0f, 0f, angle);
        transform.rotation = rotation;

        if (transform.eulerAngles.z > 90 && transform.eulerAngles.z < 270)
            transform.localScale = new Vector3(1, -1, 0);
        else
            transform.localScale = new Vector3(1, 1, 0);
    }

    void FireBullet()
    {
        timeBtwFire = TimeBtwFire;

        GameObject bulletTmp = Instantiate(bullet, firePos.position, Quaternion.identity);

        Instantiate(muzzle, firePos.position, transform.rotation, transform);

        Rigidbody2D rb = bulletTmp.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * bulletForce, ForceMode2D.Impulse);


    }

}