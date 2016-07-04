using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIShipParameter : MonoBehaviour {

    private static UIShipParameter instance;
    public static UIShipParameter Instance {
        get { return instance; }
    }

    void Awake() {
        instance = this;
    }

    Ship ship;
    public Slider powerSlider, dragSlider;
    public Text powerText, dragText;

	// Use this for initialization
	public void InitUI () {
        ship = FindObjectOfType<Ship>();
        ReadShipParameter();
	}

    private void ReadShipParameter() {
        powerSlider.value = ship.thrusterPower;
        dragSlider.value = ship.drag;
        powerText.text = ship.thrusterPower.ToString("F4");
        dragText.text = ship.drag.ToString("F4");
    }

    public void SetShipParameter() {
        if (ship == null)
            return;
        ship.thrusterPower = powerSlider.value;
        ship.drag = dragSlider.value;
        powerText.text = ship.thrusterPower.ToString("F4");
        dragText.text = ship.drag.ToString("F4");
    }
}
