using UnityEngine;
using System.Collections;

public class GoalCollider : MonoBehaviour {

	public Crowd crowd;

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("SoccerBall"))
			crowd.GoalScored();
    }
}
