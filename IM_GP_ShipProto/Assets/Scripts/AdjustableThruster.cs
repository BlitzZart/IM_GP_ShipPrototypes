using UnityEngine;
using System.Collections;

public class AdjustableThruster : MonoBehaviour
{

    public KeyCode upKey;
    public KeyCode downKey;

    private float maxPower;
    private float currentPower;
    private float particleLifetime = 0.6f;


    private Ship ship;

    private Rigidbody2D body;
    private GameObject afterBurner;

    // Use this for initialization
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        ship = GetComponentInParent<Ship>();
        afterBurner = transform.GetChild(0).gameObject;
        afterBurner.SetActive(false);

        currentPower = 0.0f;
        maxPower = ship.thrusterPower;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(upKey))
        {
            currentPower += (maxPower / 5);
            if (currentPower > maxPower) currentPower = maxPower;
        }
        if (Input.GetKeyDown(downKey))
        {
            currentPower -= (maxPower / 5);
            if (currentPower < 0) currentPower = 0;
        }

        if (currentPower > 0)
        {
            body.AddForce(transform.rotation * Vector3.up * currentPower);
            afterBurner.GetComponent<ParticleSystem>().startLifetime = particleLifetime * (((100.0f * currentPower) / maxPower) / 100);
            afterBurner.SetActive(true);

        }
        else
        {
            afterBurner.SetActive(false);
        }
    }
}
