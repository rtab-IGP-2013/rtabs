using UnityEngine;
using System.Collections;

public class ExplosionForce_SCRIPT : MonoBehaviour {

	public float radius = 1.0F;
	public float power = 2.0F;

	private int explosions = 1;
    public GameObject sound;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Explode()	{
		if(explosions > 0) {
			explosions--;

			Vector3 explosionPos = transform.position;
			Collider[] colliders = Physics.OverlapSphere(explosionPos,radius);
			foreach(Collider hit in colliders) {
				if(hit && hit.rigidbody)
					hit.rigidbody.AddExplosionForce(power,explosionPos,radius,1.5F);
			}

			audio.Play();
		}
	}
		public void BigExplode()	{
		if(explosions > 0) {
			explosions--;

			Vector3 explosionPos = transform.position;
			Collider[] colliders = Physics.OverlapSphere(explosionPos,radius);
			foreach(Collider hit in colliders) {
				if(hit && hit.rigidbody)
					hit.rigidbody.AddExplosionForce(power*10,explosionPos,radius,1.5F);
			}

			audio.Play();
		}
	}

    public void ExplodeNoReset()
    {
		Debug.Log ("DERPDERP");
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach (Collider hit in colliders)
        {
            if (hit && hit.rigidbody)
                hit.rigidbody.AddExplosionForce(power, explosionPos, radius, 1.5F);
        }

        Instantiate(sound, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}