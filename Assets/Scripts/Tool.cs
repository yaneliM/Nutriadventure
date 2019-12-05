using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool : MonoBehaviour
{
	
	int ct_killswitch;
	public GameObject myself;
    Selecter selecter;
    // Start is called before the first frame update
    void Start()
    {
        ct_killswitch = 0;
		selecter = FindObjectOfType<Selecter>();
	}
	
    void OnCollitionEnter(Collision other)
    {

        //Delete at the end of the collition
        Destroy(other.transform.gameObject);

    }

    // Update is called once per frame
    void Update()
    {
		ct_killswitch++;
		if(ct_killswitch >= 150)
		{
			Destroy(myself);
		}
    }
	
    


}
