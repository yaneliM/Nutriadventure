using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class G_Foes : Foes
{
    
    public int Verduras;
    public int Frutas;
    public int Animal;
    public int Cereales;
    public int Dulces;
    public int lacteos;


	public G_Foes(string name, int points){
		
		this.Name = name;
		this.Points = points;
		
	}
	
	
    // Start is called before the first frame update
    void Start()
    {

	
    }

    // Update is called once per frame

	
    private void Update()
	{
		
    }

    void movement_degree()
    {



        //Si calculo el angulo interno, y luego hago regla de 3 para sacar el nuevo largo de la hipotenusa
        //podria calcular los catetos, de forma independiente, con el angulo interno y el angulo recto-
   /*      SigX = (comida.position.x > 0  ?  1 : -1);
        SigZ = (comida.position.z > 0  ?  1 : -1);

            //comida.rotation = new Quaternion(comida.rotation.x,comida.rotation.y+0.1f,comida.rotation.z,1);
            cuerpo.drag = 30;

        if(SigX == 1 && SigZ == 1)
        {
            comida.position = new Vector3(comida.position.x-1,comida.position.y,comida.position.z+1);
        }  
        else if(SigX == -1 && SigZ == 1)
        {
            comida.position = new Vector3(comida.position.x-1,comida.position.y,comida.position.z-1);
        }
        else if(SigX == -1 && SigZ == -1)
        {
            comida.position = new Vector3(comida.position.x+1,comida.position.y,comida.position.z-1);
        }
        else
        {
            comida.position = new Vector3(comida.position.x+1,comida.position.y,comida.position.z+1);
        }
        */
    }
	

	
	

	
	
}
