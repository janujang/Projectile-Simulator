using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelDestroyer : MonoBehaviour {

    public GameObject menuController;
    public GameObject numPadController;

    public void Kill()
    {
        gameObject.SetActive(false);
        menuController.SetActive(true);
        numPadController.SetActive(true);
    }
}
