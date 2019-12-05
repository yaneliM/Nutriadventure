using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
  //	public Aux_Foe List_prefabs;
	
	public List<Foes> Foe_List = new List<Foes>(); 
	private int ct_frame;
	private int ct_sec;
	private int ct_enemies;
	//Crear lista 
 	


	private string[,] lista_comida = new string[,] {{"Banana","ManzanaM","NaranajaM","NaranjaC","Paleta"},//Desayuno
													  {"Carne","ManzanaM","NaranajaM","NaranjaC","Paleta"},//comida
													  {"Carne","ManzanaM","NaranajaM","NaranjaC","Paleta"}};//Cena



	// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ct_enemies = Foe_List.Count;
		
		ct_frame++;
		if(ct_frame == 30)
		{
		
			ct_frame = 0;
			ct_sec++;
			
			if(ct_sec == 5)
			{
			
				ct_sec = 0;
				if(ct_enemies <= 15)
					Spawn();
			
			}
		
		}	
			
	}
	
	public void Spawn()
	{

		G_Foes food = Resources.Load(lista_comida[0,Random.Range(0,5)],typeof(G_Foes))as G_Foes;
		Instantiate(food,Spawn_position(),Quaternion.identity);
		//Debug.Log(food.name);
		Foe_List.Add(food);
		
	}

	Vector3 Spawn_position()
		{
			int SPx = 0;
			int SPy = 0;
			int SPz = 0;
			int Dirx = 0;
			int Dirz = 0;
			int Diry = 0;



			SPx = Random.Range(1,4);
			SPz = Random.Range(1,4);
			SPy = Random.Range(1,4);

			while(Dirx == 0)
			{
				Dirx = Random.Range(-1,2);
			}
			while(Dirz == 0)
			{
				Dirz = Random.Range(-1,2);
			}
			while(Diry == 0)
			{
				Diry = Random.Range(-1,2);
			}
			if(Dirx == -1)
			{
				//Debug.Log("Izquierda");
			}
			else
			{
				//Debug.Log("Derecha");
			}
			if(Dirz == -1)
			{
				//Debug.Log("Atras");
			}
			else
			{
				//Debug.Log("Enfrente");
			}



			return new Vector3(Dirx*SPx*7,Diry*SPy*7,Dirz*SPz*7); //Direccion * Distancia * 

		} 
	
}
	
	

