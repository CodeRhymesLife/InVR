using UnityEngine;
using System.Collections;

public class soccerBall : MonoBehaviour {

    public float DelayBeforeKick = 2;
    public float KickForce = 1;
	public GameObject Goal;
	public Crowd crowd;

	private Rigidbody _rigidBody;
    private float _timeBeforeKick;
    private bool _shooting;
	private AudioSource _kick;

	public bool Scored { get; set; }

    // Use this for initialization
    void Start () {
        _shooting = false;
        _timeBeforeKick = DelayBeforeKick;
		_rigidBody = GetComponent<Rigidbody>();
		_kick = GetComponent<AudioSource>();
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

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Hand"))
		{
			crowd.GoalSaved();
		}
	}

	private void Shoot()
    {
        float yDir = Random.Range(0.43f, 0.55f);
        float zDir = Random.Range(-0.05f, 0.05f);
        Vector3 direction = new Vector3(1, yDir, zDir);
        _rigidBody.AddForce(direction * KickForce);
		_kick.Play();
    }
}
