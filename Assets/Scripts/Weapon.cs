using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public float damage;
    public float fireRate = 10;
    public float range = 150;
    public float force = 300;
    private float nexfire = 0;

    public AudioClip shotSFX;
    public AudioSource audioSource;

    public ParticleSystem muzzleFlash;
    public Transform bulletSpawn;
    public GameObject ak;

    public GameObject explosion;
    public GameObject explosionNorm;

    public Camera _cam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nexfire) {
            // ak.GetComponent<Animator>().SetTrigger("Shoot");
            nexfire = Time.time + 1f / fireRate;
            Shoot();
        }
        if (Input.GetButtonUp("Fire1")) {
            // ak.GetComponent<Animator>().SetBool("Shoot", false);
        }


        if (Input.GetKeyDown(KeyCode.O)) {
            Explosion();
        }
    }

    void Shoot() {
        // Instantiate(muzzleFlash, bulletSpawn.position, bulletSpawn.rotation);
        audioSource.PlayOneShot(shotSFX);
        muzzleFlash.Play();

        RaycastHit hit;
        if (Physics.Raycast(_cam.transform.position, _cam.transform.forward, out hit, range) && hit.collider.name != "FPSController") {

            Instantiate(explosionNorm, hit.point, Quaternion.LookRotation(hit.normal));
            /* if (hit.rigidbody != null) {
                hit.rigidbody.AddForce(-hit.normal * force);
            } */
        }
    }

    void Explosion() {
        RaycastHit _hitInfo;
        // If we hit something
        if (Physics.Raycast(_cam.transform.position, _cam.transform.forward, out _hitInfo)) {
            // Create an explosion at the impact point
            Instantiate(explosion, _hitInfo.point, Quaternion.LookRotation(_hitInfo.normal));
        }
    }
}
