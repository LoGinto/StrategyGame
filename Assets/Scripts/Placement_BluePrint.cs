﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placement_BluePrint : MonoBehaviour
{
    RaycastHit hit;
    Vector3 movePoint;
    public GameObject prefab;
    Camera kamera;
    public Material redMaterial;
    public Material whiteTransparent;
    bool canSpawn = true;
   // public LayerMask prohibitedLayer;
    // Start is called before the first frame update
    void Start()
    {
        if(kamera == null)
        {
            kamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        }
        Ray ray = kamera.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction,Color.red);
        if (Physics.Raycast(ray, out hit))
        { 
            transform.position = hit.point;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = kamera.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction,Color.red);
        if (Physics.Raycast(ray, out hit))
        {
            transform.position = hit.point;
        }
        if (Input.GetMouseButton(0))
        {
            if (canSpawn == true)
            {
                Instantiate(prefab, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
    }
}