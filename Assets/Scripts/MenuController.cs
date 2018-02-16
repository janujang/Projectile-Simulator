using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using HoloToolkit.Unity.InputModule;


public class MenuController : MonoBehaviour
{

    public GameObject menu;
    public GameObject tutorial;

    public Text speedInput;
    public Text angleInput;
    public Text horizontalDistanceLbl;
    public Text verticalDistanceLbl;
    public Text suggestedAngle;
    public Text suggestedSpeed;

    public Transform cursor;
    public Transform cannon;
    public Transform target;

    private float horizontalDistance;
    private float verticalDistance;
    private float speed;
    private float angle;

    private bool paused = false;
    private bool justStarted = true;

    // Use this for initialization
    void Start()
    {
        paused = false;
        menu.SetActive(paused);
        speedInput.text = "4.76";
        speed = 5.0f;
        angleInput.text = "30";
        angle = 30.0f;
        horizontalDistanceLbl.text = "30";
        verticalDistanceLbl.text = "50";
        ChangeSuggestedSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            Pause();
            //Debug.Log("Paused/Unpaused");
        }

        if (paused)
        {
            menu.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            menu.SetActive(false);
            Time.timeScale = 1;
        }

        //Get Horizontal and Vertical Distances
        horizontalDistance = Mathf.Sqrt(Mathf.Pow(cannon.position.x - target.position.x, 2) + Mathf.Pow(cannon.position.z - target.position.z, 2));
        verticalDistance = target.position.y - cannon.position.y;

        horizontalDistanceLbl.text = horizontalDistance.ToString();
        verticalDistanceLbl.text = verticalDistance.ToString();

        if (justStarted)
        {
            justStarted = false;
            ChangeSuggestedSpeed();
            ChangeSpeed();
            ChangeAngle();
        }
    }
    public void Pause()
    {
        paused = !paused;
        ChangeSuggestedSpeed();
    }

    public void placeCannon()
    {
        paused = false;
        //Debug.Log ("Place Cannon Pressed!");

        cannon.position = cursor.position;
    }
    public void placetarget()
    {
        paused = false;
        //Debug.Log ("Place Target Pressed!");

        target.position = cursor.position;
    }

    public void ChangeSpeed()
    {
        if (speedInput.text != "" && speedInput.text != ".")
        {
            speed = float.Parse(speedInput.text);
            CannonPointer.firingSpeed = speed;
        }
    }

    public void ChangeAngle()
    {
        if (angleInput.text != "" && angleInput.text != ".")
        {
            angle = float.Parse(angleInput.text);
            CannonPointer.firingAngle = angle;
            ChangeSuggestedSpeed();
        }
    }

    //Calculates a speed to hit the target
    public void ChangeSuggestedSpeed()
    {
        if (angle == 90f || angle == 270f)
        {
            if (horizontalDistance < 0.5f)
            {
                if (verticalDistance <= 0f)
                {
                    suggestedSpeed.text = "Suggested Speed: " + 0f.ToString();
                    return;
                }

                if (angle == 90f)
                {
                    float v = Mathf.Sqrt(2f * 9.8f * verticalDistance);
                    suggestedSpeed.text = "Suggested Speed: " + v.ToString("F3");
                    return;
                }
            }

            suggestedSpeed.text = "Suggested Speed: N/A";
            return;
        }

        float theta = angle * (Mathf.PI / 180f);

        if (verticalDistance == horizontalDistance * Mathf.Tan(theta))
        {
            suggestedSpeed.text = "Suggested Speed: N/A";
            //Debug.Log("special case");
            return;
        }

        float vSquared = (-4.9f * horizontalDistance * horizontalDistance) / ((verticalDistance * Mathf.Pow(Mathf.Cos(theta), 2)) - (horizontalDistance * Mathf.Sin(theta) * Mathf.Cos(theta)));

        if (vSquared < 0)
        {
            suggestedSpeed.text = "Suggested Speed: N/A";
            //Debug.Log("negative vSquared");
            return;
        }

        suggestedSpeed.text = "Suggested Speed: " + Mathf.Sqrt(vSquared).ToString("F3");
    }

    public void StartOver()
    {
        tutorial.SetActive(true);

        cannon.position = new Vector3(-1, 0, 3);
        target.position = new Vector3(1, 0, 3);

        justStarted = true;
        Start();

    }
}
