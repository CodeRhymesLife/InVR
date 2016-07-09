using UnityEngine;
using System.Collections;

public class soccerBall : MonoBehaviour {

    public float DelayBeforeKick = 2;
    public float KickForce = 1;
	public GameObject Goal;

	private Rigidbody _rigidBody;
    private float _timeBeforeKick;
    private bool _shooting;

    // Use this for initialization
    void Start () {
        _shooting = false;
        _timeBeforeKick = DelayBeforeKick;
		_rigidBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        _timeBeforeKick -= Time.deltaTime;
        if (!_shooting && _timeBeforeKick <= 0)
        {
            Shoot();
            _shooting = true;
        } 
	}

    private void Shoot()
    {/*
        // Get the goal's size
        MeshRenderer goalRenderer = Goal.GetComponent<MeshRenderer>();
        Bounds goalBounds = goalRenderer.bounds;

        Vector3 goalCenter = goalBounds.center;
        Vector3 goalExtents = goalBounds.extents;

        Debug.Log("Goal center: " + goalCenter);
        Debug.Log("Goal Extents: " + goalExtents);

        float percentOfXExtent = Random.Range(-1, 1);
        float percentOfYExtent = Random.Range(-1, 1);
        Vector3 shotPosition = goalCenter + new Vector3(goalExtents.x * percentOfXExtent, goalExtents.y * percentOfYExtent, 0);
        Debug.Log("Shot position: " + shotPosition);

        // Get a vector pointing towards the goal
        Vector3 heading = shotPosition - transform.position;
        float distance = heading.magnitude;
        Vector3 direction = heading / distance; // This is now the normalized direction.
        Debug.Log("Heading: " + heading);
        Debug.Log("Direction: " + direction);
        */

        float yDir = Random.Range(0.3f, 0.6f);
        float zDir = Random.Range(-0.1f, 0.1f);
        Vector3 direction = new Vector3(1, yDir, zDir);
        _rigidBody.AddForce(direction * KickForce);
    }
}
