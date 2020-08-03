using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MovePlayerNew : MonoBehaviour {
	[SerializeField]
	private float _speed = 1.0f;
    private int j = 0;
	private Rigidbody _rigidbody;
	private Vector3 _position;
	public GameObject _maincamera;
    [SerializeField]
    public GameObject _deathbox;
    [SerializeField]
    private Vector3 _offset;
    [SerializeField]
    private float jumpForce;
    private Vector3 _jump;
    [SerializeField]
    private int lives = 3;
    [SerializeField]
    private bool _speedup;
    private bool _grounded;
   
    private float elapsed;
    private float timer = 4;
    [SerializeField]
    private int _maxspeed = 30;
    private bool _jumpup;
    private float elapsedJ;
    private int i = 0;
    [SerializeField]
    private Light lt;
    [SerializeField]
    private Button reset;
    
    [SerializeField]
    private Text liveText;

    [SerializeField]
    private Text gameOver;
    [SerializeField]
    private Text nextLevel;
    [SerializeField]
    GameObject canvas;
    [SerializeField]
    private Text timeToNextLevel;
    [SerializeField]
    private Text levelText;
    [SerializeField]
    private Text scoreText;

    private Renderer render;
    private float _tempvel;

    private Color normalColor;
    private bool _invince = false;
    [SerializeField]
    private GameObject renderBody;
    private float timeForLev = 30;
    private float elapsedI;
    private int x = 0;

    public static int level = 0;
    public static int score = 0;

    private void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.Space) && _grounded)
        {
            if (_jumpup == false)
            {
                _jump = new Vector3(x: 0, y: jumpForce, z: 0);
                _rigidbody.AddForce(_jump * _speed/20.0f);

            }
            else
            {
                _jump = new Vector3(x: 0, y: jumpForce*1.5f, z: 0);
                _rigidbody.AddForce(_jump * _speed/20.0f);
            }
        }
    }

	void Start () {
        level = level + 1;
        lt.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f),  Random.Range(0f, 1f));
    _rigidbody = gameObject.GetComponent<Rigidbody>();
        //_maincamera = gameObject.FindGameObjectsWithTag("MainCamera");
        render =renderBody.GetComponent<Renderer>();
        _speedup = false;
        _jumpup = false;
        elapsedJ = 0;
        elapsed = 0;
        elapsedI = 0;
        _tempvel = _speed;
    }

	void FixedUpdate(){

        liveText.text = "Lives: " + lives.ToString();
        levelText.text = "Level: " + level.ToString();
        scoreText.text = "Score: " + score.ToString();

        FollowPlayer();
        FollowPlayerDeath();
        //_rigidbody.velocity = new Vector3(_rigidbody.velocity.x, _rigidbody.velocity.y - 1, _rigidbody.velocity.z);

        if (x == 1)
        {
            _rigidbody.velocity = new Vector3(0, _rigidbody.velocity.y, 0);
        }
        else if (timeForLev < 0 && x == 0)
        {
            if (((float)score / level) > 5)
            {
                _rigidbody.position = new Vector3(0, 0.5f, -24.25792f);
                Text tempText = Instantiate(nextLevel, _rigidbody.position, Quaternion.identity);
                tempText.transform.SetParent(canvas.transform, false);
                tempText.fontSize = 20;
                tempText.text = "Continue to the next Level?";
                x = x + 1;
                Button tempButton = Instantiate(reset, _rigidbody.position, Quaternion.identity);
                tempButton.GetComponentInChildren<Text>().text = "Next Level";

                tempButton.transform.SetParent(canvas.transform, false);
            }
            else
            {
                _rigidbody.position = new Vector3(0, 0.5f, -24.25792f);
                Text tempText = Instantiate(nextLevel, _rigidbody.position, Quaternion.identity);
                tempText.transform.SetParent(canvas.transform, false);
                tempText.fontSize = 20;
                tempText.text = "Not Enough coins try Again.";
                
                Button tempButton = Instantiate(reset, _rigidbody.position, Quaternion.identity);
                tempButton.GetComponentInChildren<Text>().text = "Retry Level";

                tempButton.transform.SetParent(canvas.transform, false);
            }




        }
        else if (i == 1)
        {
            _rigidbody.velocity = new Vector3(0, _rigidbody.velocity.y, 0);
        }
        else if (lives == 0 && i == 0)
        {
            _rigidbody.position = new Vector3(0, 0.5f, -24.25792f);
            Text tempText = Instantiate(gameOver, _rigidbody.position, Quaternion.identity);
            tempText.transform.SetParent(canvas.transform, false);
            tempText.fontSize = 20;
            tempText.text = "GAME OVER!!!";
            i = i + 1;
            Button tempButton = Instantiate(reset, _rigidbody.position, Quaternion.identity);
            tempButton.transform.SetParent(canvas.transform, false);
            tempButton.GetComponentInChildren<Text>().text = "Try again?";
            score = 0;
            level = 0;



        }
        else
        {
            movePlayer();
            timeForLev -= Time.deltaTime;
            timeToNextLevel.text = "Level Complete in:" + timeForLev.ToString();
            if (_speedup == false)
            {
                _rigidbody.velocity = Vector3.ClampMagnitude(_rigidbody.velocity, _maxspeed);
                
            }
            if (_speedup == true)
            {
                if (elapsed == 0)
                {
                    _speed = _speed * 1.75f;
                }

                elapsed += Time.deltaTime;
                if (elapsed >= timer)
                {
                    _speedup = false;
                    elapsed = 0f;
                    _speed = _tempvel;
                }

            }

            if (_jumpup == true)
            {
                elapsedJ += Time.deltaTime;
                if (elapsedJ >= timer)
                {
                    elapsedJ = 0f;
                    _jumpup = false;
                }
            }
            if (_invince == true)
            {
                elapsedI += Time.deltaTime;
                if (elapsedI >= timer)
                {
                    elapsedI = 0f;
                    _invince = false;
                }
            }
        }

	}

	private void movePlayer(){

        float horizontalValue = Input.GetAxis("Horizontal");

        gameObject.transform.Translate(x:horizontalValue*_speed*Time.deltaTime*(level/20.0f), y:0, z:_speed*Time.deltaTime * (level / 20.0f));
	}

	private void FollowPlayer()
	{
		if (_maincamera != null) {
			// i want to follow the player with some offset
			_maincamera.gameObject.transform.position = gameObject.transform.position +_offset;
		
		} else {
			Debug.LogError (message: "no main camera rigid body");
		
		}
	
	
	}


    private void FollowPlayerDeath()
    {
        if (_deathbox != null)
        {
            // i want to follow the player with some offset
            _deathbox.gameObject.transform.position = new Vector3(gameObject.transform.position.x, -12, gameObject.transform.position.z );

        }
        else
        {
            Debug.LogError(message: "no main camera rigid body");

        }


    }

    private void MovePlayer2(){
		if (_rigidbody != null) {

            float horizontalValue = Input.GetAxis ("Horizontal");
            float verticalValue = 1f;// Input.GetAxis ("Vertical");
	
			_position = new Vector3 (x: horizontalValue, y: 0, z: verticalValue);
			_rigidbody.AddForce (_position * _speed);
		} 
		else {
		
			Debug.LogError (message: "no player rigid body");
		
		}
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DeathBox"))
        {
            lives = lives - 1;
            gameObject.transform.position = new Vector3(0, 10, gameObject.transform.position.x-30);
            _rigidbody.velocity = new Vector3(0, 0, 0);
        }

        if (other.CompareTag("ground"))
        {
            _grounded = true;
        }
        if (other.CompareTag("speedup"))
        {
            
            _speedup = true;
            _rigidbody.AddForce(new Vector3(0,0,10),ForceMode.VelocityChange);
            Destroy(other.gameObject);
            
        }
        if (other.CompareTag("jumpUp"))
        {

            _jumpup = true;
            Destroy(other.gameObject);

        }
        if (other.CompareTag("invincePickUp"))
        {
            _invince = true;
            Destroy(other.gameObject);
        }

        if (other.CompareTag("enemy"))
        {

            Destroy(other.gameObject);
            if (_invince == false)
            {
                StartCoroutine("Flasher");
                lives = lives - 1;
       
            }

        }
        if (other.CompareTag("coin"))
        {
           score = score + 1;
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("ground"))
        {
            _grounded = false;
        }
    }

    private IEnumerator Flasher()
    {
        for ( j = 0; j < 5; j++)
        {

            normalColor = render.material.color;
            render.material.color = Color.red;
            yield return new WaitForSeconds(.1f);
            render.material.color = normalColor;
            yield return new WaitForSeconds(.1f);
        }
    }

}
