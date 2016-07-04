using UnityEngine;
using System.Collections;

public class ShipSelector : MonoBehaviour {

    public GameObject ship1, ship2, ship3;

    // Use this for initialization
    void Start() {

    }

    void DestroyAllShips() {
        Ship[] ships = FindObjectsOfType<Ship>();

        for (int i = 0; i < ships.Length; i++) {
            GameObject.Destroy(ships[i].gameObject);
        }
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKey(KeyCode.LeftShift)) {
            if (Input.GetKeyDown(KeyCode.Alpha1)) {
                DestroyAllShips();
                Instantiate(ship1);
                UIShipParameter.Instance.InitUI();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2)) {
                DestroyAllShips();
                Instantiate(ship2);
                UIShipParameter.Instance.InitUI();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3)) {
                DestroyAllShips();
                Instantiate(ship3);
                UIShipParameter.Instance.InitUI();
            }
        }
    }
}
