using UnityEngine;


public class MovePlayer : MonoBehaviour {
	[SerializeField]
	private float _speed = 1.0f;

	private Rigidbody _rigidbody;
	private Vector3 _position;
	public GameObject _maincamera;
	[SerializeField]
    private Vector3 _offset;
    [SerializeField]
    private float jumpForce;
    private Vector3 _jump;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _jump = new Vector3(x: 0, y: jumpForce, z: 0);
            _rigidbody.AddForce(_jump * _speed);
        }
    }

	void Start () {
		_rigidbody = gameObject.GetComponent<Rigidbody>();
		//_maincamera = gameObject.FindGameObjectsWithTag("MainCamera");
	}

	void FixedUpdate(){
		MovePlayer2();
        FollowPlayer();
	}

	//private void movePlayer(){
		
	//	gameObject.transform.Translate(x:0, y:0, z:Time.deltaTime * _speed);
	//}

	private void FollowPlayer()
	{
		if (_maincamera != null) {
			// i want to follow the player with some offset
			_maincamera.gameObject.transform.position = gameObject.transform.position +_offset;
		
		} else {
			Debug.LogError (message: "no main camera rigid body");
		
		}
	
	
	}

	private void MovePlayer2(){
		if (_rigidbody != null) {

			float horizontalValue = Input.GetAxis ("Horizontal");
			float verticalValue = Input.GetAxis ("Vertical");
	
			_position = new Vector3 (x: horizontalValue, y: 0, z: verticalValue);
			_rigidbody.AddForce (_position * _speed);
		} 
		else {
		
			Debug.LogError (message: "no player rigid body");
		
		}
	}

   
}
