using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouvement : MonoBehaviour
{
    private float previousTime;
    public float fallTime = 0.1f;
    public static int height = 16;
    public static int width = 9;
    public bool playable = true;

    // Update is called once per frame
    void Update()
    {
        if (playable == true)
        {
            ///////////////////
            ///Sur Téléphone///
            ///////////////////
            if (Input.touchCount > 0)
            {
                var touch = Input.touches[0];
                if (touch.position.x < Screen.width / 2)
                {
                    if (Input.GetTouch(0).phase == TouchPhase.Began)
                    {
                        transform.position += new Vector3(-1, 0, 0);
                        if (!ValidMove())
                            transform.position -= new Vector3(-1, 0, 0);
                    }
                }
                else if (touch.position.x > Screen.width / 2)
                {
                    if (Input.GetTouch(0).phase == TouchPhase.Began)
                    {
                        transform.position += new Vector3(1, 0, 0);
                        if (!ValidMove())
                            transform.position -= new Vector3(1, 0, 0);
                    }
                }
            }
            else
            ////////////////////
            ///Sur Ordinateur///
            ////////////////////
            {
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    transform.position += new Vector3(-1, 0, 0);
                    if (!ValidMove())
                        transform.position -= new Vector3(-1, 0, 0);
                }
                else if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    transform.position += new Vector3(1, 0, 0);
                    if (!ValidMove())
                        transform.position -= new Vector3(1, 0, 0);
                }
                else if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    transform.Rotate(0, 0, 90);
                    if (!ValidMove())
                        transform.Rotate(0, 0, -90);
                }
                else if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    transform.Rotate(0, 0, -90);
                    if (!ValidMove())
                        transform.Rotate(0, 0, 90);
                }
            }
        }
        if(transform.position.y < -.5)
        {
            if (playable == true)
            {
                FindObjectOfType<SpawningForme>().NewForme();
            }
            playable = false;
            Destroy(gameObject);
        }
    }

    bool ValidMove()
    {
        foreach(Transform children in transform)
        {
            int roundedX = Mathf.RoundToInt(children.transform.position.x);
            int roundedY = Mathf.RoundToInt(children.transform.position.y);

            if(roundedX < 0 || roundedX>= width || roundedY < 0 || roundedY>= height)
            {
                return false;
            }
        }
        return true;
    }

    void OnCollisionEnter()
    {
        if (playable == true)
        {
            FindObjectOfType<SpawningForme>().NewForme();
        }
        playable = false;

    }

}
