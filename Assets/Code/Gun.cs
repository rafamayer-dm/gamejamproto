using UnityEngine;

public class Gun : MonoBehaviour
{
    [Header("Configurações de Disparo")]
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 50f;

    [Header("Mira da Arma")]
    public Transform cameraTransform; // Arraste a MainCamera (ou FPS) para aqui
    public float aimDistance = 50f; // Distância para onde a arma tentará olhar

    void Update()
    {
        AimGun();

        if (!ScoreManager.gameOver && Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void AimGun()
    {
        if (cameraTransform == null) return;

        Vector3 targetPoint = cameraTransform.position + cameraTransform.forward * aimDistance;

        // O transform.parent refere-se ao novo 'GunPivot'
        if (transform.parent != null)
        {
            transform.parent.LookAt(targetPoint);
        }
        else
        {
            transform.LookAt(targetPoint); // Fallback caso não tenha feito o Pivot
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = firePoint.forward * bulletSpeed;
        }
    }
}