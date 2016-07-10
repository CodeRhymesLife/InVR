using UnityEngine;
using System.Collections;

public class BallManager : MonoBehaviour {

    public soccerBall OriginalBall;
    public float DelayBeforeNextBall = 5;
    public GameObject Goal;
	public Crowd crowd;

    private float _timeBeforeNextBall;

    // Use this for initialization
    void Start () {
        _timeBeforeNextBall = 0;
    }
	
	// Update is called once per frame
	void Update () {
        _timeBeforeNextBall -= Time.deltaTime;
        if (_timeBeforeNextBall <= 0)
        {
            // Create a ball and make it a child of this container
            soccerBall ball = Instantiate(OriginalBall, new Vector3(20f, 1f), Quaternion.identity) as soccerBall;
            ball.Goal = Goal;
			ball.crowd = crowd;
            ball.transform.parent = gameObject.transform;

            _timeBeforeNextBall = DelayBeforeNextBall;
        }
    }
}
