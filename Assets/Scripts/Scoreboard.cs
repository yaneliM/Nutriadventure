using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour
{
    
	public int health=0;

	float G_Carne;
	float G_Lacteos;
	float G_Verduras;
	float G_Frutas;
	float G_Cereales;
	float G_candy;

    public int Score=0;
    public float Carne=0;
    public float Lacteos=0;
    public float Verduras=0;
    public float Cereales=0;
    public float Frutas=0;
	
	public float total;
	public float M_Carne;
	public float M_Lacteos;
	public float M_Verduras;
	public float M_Cereales;
	public float M_Frutas;
	
	//public Text L_Score;
	public Image _Carne;
	public Image _Lacteos;
	public Image _Verduras;
	public Image _Cereales;
	public Image _Frutas;

	public bool carne_f;
	public bool lacteos_f;
	public bool verduras_f;
	public bool cereales_f;
	public bool frutas_f;

	Selecter SL;
	
    void Start()
    {
		SL = FindObjectOfType<Selecter>();
		clear_sprites();
		Debug.Log("Start");
		total = 0;
		health = 50;
		
		carne_f=false;
		lacteos_f=false;
		verduras_f=false;
		cereales_f=false;
		frutas_f=false;
		
    }


    // Update is called once per frame
    void Update()
    {
        
		
		
    }
	
	public void Update_Sprites()
	{
		clear_sprites();
		_Carne.fillAmount += Carne / M_Carne;
		_Cereales.fillAmount += Cereales / M_Cereales;
		_Verduras.fillAmount += Verduras / M_Verduras;
		_Frutas.fillAmount += Frutas / M_Frutas;
		_Lacteos.fillAmount += Lacteos / M_Lacteos;
		
		
	}
	
	void clear_sprites()
	{
		
		_Carne.fillAmount -= 1;
		_Cereales.fillAmount -= 1;
		_Verduras.fillAmount -= 1;
		_Frutas.fillAmount -= 1;
		_Lacteos.fillAmount -= 1;

	}
	
	public void update_score(G_Foes c)
	{
		if(c.Animal>0)
		{
			if(carne_f)
				health -=15;
			else
				health +=8;
		}
				
		if(c.Verduras>0)
		{
			if(verduras_f)
				health -=15;
			else
				health +=8;
		}

		if(c.Frutas>0)
		{
			if(frutas_f)
				health -=15;
			else
				health +=8;
		}		
		
		if(c.Cereales>0)
		{
			if(cereales_f)
				health -=15;
			else
				health +=8;
		}
		
		if(c.lacteos > 0)
		{
			if(lacteos_f)
				health -=15;
			else
				health +=8;
		}

		if(isCandyDestroyed(c))
		{

			G_candy += 1;

		}


		if(SL.account){
		this.Carne += c.Animal*(1/M_Carne);
		this.Lacteos += c.lacteos*(1/M_Lacteos);
		this.Verduras += c.Verduras*(1/M_Verduras);
		this.Cereales += c.Cereales*(1/M_Cereales);
		this.Frutas += c.Frutas*(1/M_Frutas);
		this.Score += c.Points;

		total += 0.7f; 
		}
	
		Check_carne();
		Check_cereales();
		Check_fruta();
		Check_lacteos();
		Check_verduras();

	}
	
	public bool Check_carne()
	{
		carne_f = (Carne >= M_Carne ? true : false);
		return carne_f;
	}
	public bool Check_verduras()
	{
		verduras_f = (Verduras >= M_Verduras ? true : false);
		return verduras_f;
	}
	public bool Check_fruta()
	{
		frutas_f = (Frutas >= M_Frutas ? true : false);
		return frutas_f;
	}
	public bool Check_cereales()
	{
		cereales_f = (Cereales >= M_Cereales ? true : false);
		return cereales_f;
	}
	public bool Check_lacteos()
	{
		lacteos_f = (Lacteos >= M_Lacteos ? true : false);
		return lacteos_f;
	}

	public int score_value()
	{
		return this.Score;
	}

	void OnDisable()
	{
		
	G_Carne += Carne;
	G_Lacteos += Lacteos;
	G_Verduras += Verduras;
	G_Frutas += Frutas;
	G_Cereales += Cereales;

	}

	bool isCandyDestroyed(G_Foes g)
	{
		if(g.Animal == 0 && g.Cereales == 0 && g.Frutas == 0 && g.Verduras == 0 && g.lacteos == 0)
		{
			if(SL.account)
			{
				return true;
			}
			else
			return false;
		}
		else
		return false; 
	}

	void Awake()
	{
	/* 	
	G_Carne ;
	G_Lacteos ;
	G_Verduras ;
	G_Frutas ;
	G_Cereales ;
		Aqui deben cargar los valores guardados DANNY
	*/

	}
}
