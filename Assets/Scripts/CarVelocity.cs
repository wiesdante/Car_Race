using System.Collections;
using UnityEngine;

public class CarVelocity: MonoBehaviour {
	private Rigidbody2D rb;
	[SerializeField]
	private Vector2 _time;
	[SerializeField]
	private Vector2 _velocity;
	
	IEnumerator RandomVelocity(Vector2 timeRange, Vector2 velocityRange) {
		var time = Random.Range(timeRange[0], timeRange[1]);
		var velocity = Random.Range(velocityRange[0], velocityRange[1]);
		var v = rb.velocity;
		v.y = velocity;
		rb.velocity = v;
		yield return new WaitForSeconds(time);
		yield return StartCoroutine(RandomVelocity(timeRange, velocityRange));
	}

	private void Start() {
		rb = GetComponent<Rigidbody2D>();
		StartCoroutine(RandomVelocity(_time, _velocity));
	}
}