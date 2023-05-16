using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shotgun : MonoBehaviour
{
    [Header("Attributes")]
	[SerializeField] private float ataque = 5f;
	[SerializeField] private float tiempoEntreDisparo = 0.5f;
	[SerializeField] private float rango = 100f;
	[SerializeField] private int cantidadDisparos = 3;
	[SerializeField] private float dispersionHorizontal = 5f;
	[SerializeField] private float dispersionVertical = 5f;
	[SerializeField] private LayerMask layerMask;
 
    [Header("GameObjects")]
	[SerializeField] private Transform cameraPrimeraPersona;
	[SerializeField] private Transform origenProyectil;
	[SerializeField] private TrailRenderer trailPrefab;
 
	private bool puedeDisparar = true;
 
	public void ProcesarEntrada(bool value)
	{
    	if (puedeDisparar && value)
    	{
            StartCoroutine(Disparar());
    	}
	}
 
	private IEnumerator Disparar()
	{
    	puedeDisparar = false;
    	for (int i = 0; i < cantidadDisparos; i++)
			{
				ProcesarRaycast();
			}
    	yield return new WaitForSecondsRealtime(tiempoEntreDisparo);
    	puedeDisparar = true;
	}
 
	private void ProcesarRaycast()
	{

	float Horizontal = Random.Range(-(dispersionHorizontal), dispersionHorizontal);
    float Vertical = Random.Range(-(dispersionVertical), dispersionVertical); 

    Vector3 direccionDisparo = CalcularDireccion();
    direccionDisparo = Quaternion.Euler(Vertical, Horizontal, 0f) * direccionDisparo;


    	if (Physics.Raycast(cameraPrimeraPersona.position, direccionDisparo, out RaycastHit hit, rango, layerMask))
    	{
        	TrailRenderer trail = Instantiate(trailPrefab, origenProyectil.transform.position, Quaternion.identity);
 
            StartCoroutine(MoverTrail(trail, hit));
 
        	if (hit.transform.TryGetComponent<Salud>(out Salud targetHealth))
        	{
                targetHealth.PerderSalud(ataque);
        	}
    	}
	}
 
	private IEnumerator MoverTrail(TrailRenderer trail, RaycastHit hit)
	{
    	float t = 0f;
 
    	while (t < 1)
    	{
            trail.transform.position = Vector3.Lerp(origenProyectil.transform.position, hit.point, t);
        	t += Time.deltaTime / trail.time;
        	yield return null;
    	}
 
    	trail.transform.position = hit.point;
    	Destroy(trail.gameObject, trail.time);
	}
 
	private Vector3 CalcularDireccion()
	{
    	Vector3 direction = cameraPrimeraPersona.forward;
    	return direction;
	}
}
