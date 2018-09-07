using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	//Esto lo puedo usar como mi contexto para aplicar el patron de Estados.

	//Atributos
	private int life;
	private int ammo;

	//Propiedades
	public int _life {get{return life;}set{life=value;}}
	public int _ammo{get{return ammo;}set{ammo = value;}}
	//Constructores
	void Awake()
	{
		life = 100;
		ammo = 0;
	}
	//Methodos

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
