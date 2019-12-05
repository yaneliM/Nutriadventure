using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selecter : MonoBehaviour
{
    private Gyroscope gyro;
    public GameObject EAT;
    public GameObject DESTROY;
    RaycastHit hitInfo;
    RaycastHit HCInfo;
    public bool selected = false;

    void Selected()
    {

		gyro.enabled = false;
        EAT.SetActive(true);
        DESTROY.SetActive(true);
        

    }

    public bool getState()
    {
       return (selected == true ? true : false);
    }

    public void Eat()
    {
        gyro.enabled = true;
        EAT.SetActive(false);
        DESTROY.SetActive(false);
        Debug.Log("A comer");
        GameObject ob = HCInfo.transform.gameObject;
        Destroy(ob);
        selected = true;
    }

    public void Discard()
    {
        gyro.enabled = true;
        EAT.SetActive(false);
        DESTROY.SetActive(false);
        Debug.Log("Al hielo <the godfather>");
        GameObject ob = hitInfo.transform.gameObject;
        Destroy(ob);
        selected = true;

    }

    // Start is called before the first frame update
    void Start()
    {
        gyro = Input.gyro;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
             //Debug.Log("Cl.icked");
             Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
             if(Physics.Raycast(ray, out hitInfo))
             {
                var rig = hitInfo.collider.GetComponent<Rigidbody>();

                if(rig != null)
                {
                    Selected();
                    HCInfo = hitInfo;
                    Debug.Log("object hit");
                }


             }
        }

    }
}
