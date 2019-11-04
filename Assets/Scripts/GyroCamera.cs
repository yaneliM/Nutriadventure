using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroCamera : MonoBehaviour
{

private Gyroscope gyro;
	private bool gyroSupported;
	private Quaternion rotMix;

	[SerializeField]
	private Transform worldObj;
	private float startY;

    // Start is called before the first frame update
    void Start() 
    {
    	gyroSupported = SystemInfo.supportsGyroscope;

    	GameObject camParent = new GameObject("camParent");
    	camParent.transform.position = transform.position;
    	transform.parent = camParent.transform;

    	if(gyroSupported){
    		gyro = Input.gyro;	
    		gyro.enabled = true;

    		camParent.transform.rotation = Quaternion.Euler(90f,90f,0f);
    		rotMix = new Quaternion(0,0,1,0);
    	}
        
    }

    // Update is called once per frame
    void Update()
    {
    	if(gyroSupported && startY == 0){
    		ResetGyroRotation();
    	}
        transform.localRotation = gyro.attitude * rotMix;
    }

    void ResetGyroRotation(){
    	startY = transform.eulerAngles.y;
    	worldObj.rotation = Quaternion.Euler(0f,startY,0f);
    }
}
