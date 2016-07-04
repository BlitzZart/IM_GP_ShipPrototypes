using UnityEngine;
using System.Collections;

public class Effects : MonoBehaviour {
    private static Effects instance;
    public static Effects Instance {
        get { return instance; }
    }

    void Awake() {
        instance = this;
    }

    public bool effectsActive = false;
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKey(KeyCode.LeftShift)) {
            if (Input.GetKeyDown(KeyCode.E))
                effectsActive = !effectsActive;
        }
    }
}