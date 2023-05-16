using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
 
public class ControlArma : MonoBehaviour
{
	[SerializeField] private Arma arma;
	[SerializeField] private Shotgun shotgun;
	[SerializeField] private Sniper sniper;
	[SerializeField] private MachineGun machine;
	
	private void Awake()
	{		
		Desactivar();
		arma.gameObject.SetActive(true);
	}

	public void Desactivar(){
		arma.gameObject.SetActive(false);
		shotgun.gameObject.SetActive(false);
		sniper.gameObject.SetActive(false);
		machine.gameObject.SetActive(false);
	}
 
	public void AlDisparar(InputAction.CallbackContext value)
	{

		if (!(ReferenceEquals(arma, null)) && arma.gameObject.activeInHierarchy){
			arma.ProcesarEntrada(value.action.triggered);		
		}

		if (!(ReferenceEquals(shotgun, null)) && shotgun.gameObject.activeInHierarchy){
			shotgun.ProcesarEntrada(value.action.triggered);		
		}
		
		if (!(ReferenceEquals(sniper, null)) && sniper.gameObject.activeInHierarchy){
			sniper.ProcesarEntrada(value.action.triggered);		
		}

		if (!(ReferenceEquals(machine, null)) && machine.gameObject.activeInHierarchy){
			machine.ProcesarEntrada(value.action.triggered);		
		}
	}


	public void CambiarArma(InputAction.CallbackContext value){
		if (value.action.triggered){
			Desactivar();
			arma.gameObject.SetActive(true);
		}
	}
	public void CambiarShotgun(InputAction.CallbackContext value){
		if (value.action.triggered){
			Desactivar();
			shotgun.gameObject.SetActive(true);
		}
	}
	public void CambiarMachine(InputAction.CallbackContext value){
		if (value.action.triggered){
			Desactivar();
			machine.gameObject.SetActive(true);
		}
	}
	public void CambiarSniper(InputAction.CallbackContext value){
		if (value.action.triggered){
			Desactivar();
			sniper.gameObject.SetActive(true);
		}
	}

		

	

}
