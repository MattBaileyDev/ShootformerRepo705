using System.Security.Permissions;
using UnityEngine;
using UnityEngine.SceneManagement;

// This is a template script for in-game object health manager.
// Any in-game entity that reacts to a shot must have this script with the public function TakeDamage().
public class HealthManager : MonoBehaviour
{
	public GameObject Damage1;
	public GameObject Damage2;
	public GameObject Damage3;
	public GameObject Damage4;

	public GameObject Damage12D;
	public GameObject Damage22D;
	public GameObject Damage32D;
	public GameObject Damage42D;

	public float phealth = 100f;
	// Class to encapsulate damage parameters for the callback function.
	public class DamageInfo
	{
		public Vector3 location, direction;      // Hit location and direction.
		public float damage;                     // Damage ammount.
		public Collider bodyPart;               // The body part (Collider) that was hit (optional).
		public GameObject origin;                // The game object that generated the hit (optional).

		public DamageInfo(Vector3 location, Vector3 direction, float damage, Collider bodyPart=null, GameObject origin=null)
		{
			this.location = location;
			this.direction = direction;
			this.damage = damage;
			this.bodyPart = bodyPart;
			this.origin = origin;
		}
	}

	[HideInInspector] public bool dead;          // Is this entity dead?
	
	// This is the mandatory function that receives damage from shots.
	// You may remove the 'virtual' keyword before coding the content.
	public virtual void TakeDamage(Vector3 location, Vector3 direction, float damage, Collider bodyPart=null, GameObject origin=null)
	{
		phealth -= damage;

		if (phealth <= 100 && phealth > 75)
        {
			Damage1.SetActive(true);
			Damage12D.SetActive(true);
		}

		if (phealth <= 75 && phealth > 50)
		{
			Damage1.SetActive(false);
			Damage12D.SetActive(false);
			Damage2.SetActive(true);
			Damage22D.SetActive(true);
		}

		if (phealth <= 50 && phealth > 25)
		{
			Damage1.SetActive(false);
			Damage12D.SetActive(false);
			Damage2.SetActive(false);
			Damage22D.SetActive(false);
			Damage3.SetActive(true);
			Damage32D.SetActive(true);
		}

		if (phealth <= 25 && phealth > 0)
        {
			Damage1.SetActive(false);
			Damage12D.SetActive(false);
			Damage2.SetActive(false);
			Damage22D.SetActive(false);
			Damage3.SetActive(false);
			Damage32D.SetActive(false);
			Damage4.SetActive(true);
			Damage42D.SetActive(true);
		}

	




		if (phealth <= 0)
		{
			dead = true;
			Damage1.SetActive(false);
			Damage12D.SetActive(false);
			Damage2.SetActive(false);
			Damage22D.SetActive(false);
			Damage3.SetActive(false);
			Damage32D.SetActive(false);
			Damage4.SetActive(true);
			Damage42D.SetActive(true);
			phealth = 0;
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}

	}



	// This is the message receiver for damage taken by a child gameObject rigidbody (ex.: ragdoll)
	public void HitCallback(DamageInfo damageInfo)
	{
		this.TakeDamage(damageInfo.location, damageInfo.direction, damageInfo.damage, damageInfo.bodyPart, damageInfo.origin);
	}
}
