using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

[AddComponentMenu("Nokobot/Modern Guns/Simple Shoot")]
public class SimpleShoot : MonoBehaviour
{
    public int maxammo = 15;
    [SerializeField]
    private int currentammo;

    [Header("Prefab Refrences")]
    public GameObject bulletPrefab;
    public GameObject casingPrefab;
    public GameObject muzzleFlashPrefab;

    [Header("Location Refrences")]
    [SerializeField] private Animator gunAnimator;
    [SerializeField] private Transform barrelLocation;
    [SerializeField] private Transform casingExitLocation;

    [Header("Settings")]
    [Tooltip("Specify time to destory the casing object")] [SerializeField] private float destroyTimer = 2f;
    [Tooltip("Bullet Speed")] [SerializeField] private float shotPower = 500f;
    [Tooltip("Casing Ejection Speed")] [SerializeField] private float ejectPower = 150f;
    TextMeshProUGUI count;

    public GameObject ammocount;
    public AudioSource source;
    public AudioClip fire;
    public AudioClip reload;
    public AudioClip noammo;

    void Start()
    {
        if (barrelLocation == null)
            barrelLocation = transform;


        if (gunAnimator == null)
            gunAnimator = GetComponentInChildren<Animator>();
        Reload();
        
        count = ammocount.GetComponentInChildren<TextMeshProUGUI>();
    }

    void Reload()
    {
        
        currentammo = maxammo;
        source.PlayOneShot(reload);
    }
    void Update()
    {
        /*
        count.text = currentammo.ToString();
        //If you want a different input, change it here
        if (Input.GetButtonDown("Fire1"))
        {
            if (currentammo > 0) {
                gunAnimator.SetTrigger("Fire");
            }
            else
            {
                source.PlayOneShot(noammo);
            }
            //Calls animation on the gun that has the relevant animation events that will fire
             //애니메이션에 발사,장전 함수내장
        }
        */
        if (Vector3.Angle(transform.up, Vector3.up) > 100 && currentammo < maxammo)
            Reload();
        count.text = currentammo.ToString();
    }
    public void firegun()
    {
        if (!Mission_imfo.isShootingFirecraker) Mission_imfo.isShootingFirecraker = true;
        if (currentammo > 0)
        {
            gunAnimator.SetTrigger("Fire");
        }
        else
        {
            source.PlayOneShot(noammo);
        }
    }

    //This function creates the bullet behavior
    void Shoot()
    {
        currentammo--;//총알 빠짐
        source.PlayOneShot(fire);
        if (muzzleFlashPrefab) //총이펙트효과
        {
            //Create the muzzle flash
            GameObject tempFlash;
            tempFlash = Instantiate(muzzleFlashPrefab, barrelLocation.position, barrelLocation.rotation);

            //Destroy the muzzle flash effect
            Destroy(tempFlash, destroyTimer);
        }

        //cancels if there's no bullet prefeb
        if (!bulletPrefab)  //총알
        { return; }

        GameObject bulletFlash;
        // Create a bullet and add force on it in direction of the barrel
        bulletFlash = Instantiate(bulletPrefab, barrelLocation.position, barrelLocation.rotation);
        bulletFlash.GetComponent<Rigidbody>().AddForce(barrelLocation.forward * shotPower);


        Destroy(bulletFlash, destroyTimer+4f);
    }

    //This function creates a casing at the ejection slot
    void CasingRelease() 
    {
        //Cancels function if ejection slot hasn't been set or there's no casing
        if (!casingExitLocation || !casingPrefab) //탄피
        { return; }

        //Create the casing
        GameObject tempCasing;
        tempCasing = Instantiate(casingPrefab, casingExitLocation.position, casingExitLocation.rotation) as GameObject;
        //Add force on casing to push it out
        tempCasing.GetComponent<Rigidbody>().AddExplosionForce(Random.Range(ejectPower * 0.7f, ejectPower), (casingExitLocation.position - casingExitLocation.right * 0.3f - casingExitLocation.up * 0.6f), 1f);
        //Add torque to make casing spin in random direction
        tempCasing.GetComponent<Rigidbody>().AddTorque(new Vector3(0, Random.Range(100f, 500f), Random.Range(100f, 1000f)), ForceMode.Impulse);

        //Destroy casing after X seconds
        Destroy(tempCasing, destroyTimer);
    }

}
