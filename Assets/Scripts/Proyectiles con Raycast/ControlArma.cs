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
 
	public void AlDisparar(InputAction.CallbackContext value)
	{
    	arma.ProcesarEntrada(value.action.triggered);
		shotgun.ProcesarEntrada(value.action.triggered);
		sniper.ProcesarEntrada(value.action.triggered);
		machine.ProcesarEntrada(value.action.triggered);
	}
}
