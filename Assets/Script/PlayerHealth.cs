using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class PlayerHealth : MonoBehaviour
{
    public float health;

    public Image healthBar;

    public Color originColor;

    public float cubeSize = 0.2f;
    public int cubeInRow = 3;
    bool isExploded = false;
    float cubesPivotDistance = 0;
    Vector3 cubesPivot;
    public float explosionForce = 50f;
    public float explosionRadius = 4f;
    public float explosionUpward = 0.4f;
    public GameObject particlePrefab;

    bool isHit = false;

    void Start()
    {
        health = 50;
        cubesPivotDistance = cubeSize * cubeInRow / 2;
        cubesPivot = new Vector3(cubesPivotDistance, cubesPivotDistance, cubesPivotDistance);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Fist" && collision.collider.GetComponentInParent<PlayerPunch>().punch && !isHit)
        {
            ScreenShakeManager.Perturb();
            isHit = true;
            StartCoroutine(GetHitChangeColor());
            health -= 10;
            healthBar.fillAmount = health / 50f;
            if (health == 0 && !isExploded)
            {
                Explode(); isExploded = true; Destroy(this.transform.parent.gameObject);
            }
        }
    }

    IEnumerator GetHitChangeColor()
    {
        for (int i = 0; i < 2; i++)
        {
            foreach (MeshRenderer child in this.GetComponentsInChildren<MeshRenderer>())
            {
                if (child.name == "Capsule")
                    originColor = child.material.color;
            }
            foreach (MeshRenderer child in this.GetComponentsInChildren<MeshRenderer>())
            {
                if (child.name == "Capsule" || child.name == "LHand" || child.name == "RHand")
                    child.material.color = Color.magenta;
            }
            yield return new WaitForSeconds(0.2f);
            foreach (MeshRenderer child in this.GetComponentsInChildren<MeshRenderer>())
            {
                if (child.name == "Capsule" || child.name == "LHand" || child.name == "RHand")
                    child.material.color = originColor;
            }
        }
        isHit = false;
    }

    void Explode()
    {
        for (int i = 0; i < cubeInRow; ++i)
        {
            for (int j = 0; j < cubeInRow; ++j)
            {
                for (int k = 0; k < cubeInRow; ++k)
                {
                    CreatePiece(i, j, k);
                }
            }
        }

        Vector3 explosionPosition = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPosition, explosionRadius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius, explosionUpward);
            }
        }

        Destroy(this.gameObject);
    }

    void CreatePiece(int x, int y, int z)
    {
        GameObject piece;
        piece = Instantiate(particlePrefab, transform.position, transform.rotation);

        piece.transform.position = transform.position + new Vector3(cubeSize * x, cubeSize * y, cubeSize * z) - cubesPivot;
        piece.transform.localScale = new Vector3(cubeSize, cubeSize, cubeSize);

        piece.AddComponent<Rigidbody>();
        piece.GetComponent<Rigidbody>().mass = cubeSize;

        Destroy(piece, 0.5f);
    }
}
