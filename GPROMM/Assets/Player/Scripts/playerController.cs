using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class playerController : MonoBehaviour {
    [SerializeField]
    private float _speed = 5.0f;
    private Vector3 _playerPosition;
    [SerializeField]
    private GameObject FireObject;
    [SerializeField]
    private int lives = 3;
    [SerializeField]
    private GameObject GameOver;
    [SerializeField]
    private GameObject Enemyprefab;

    [SerializeField]
    private Text livesNum;
	// Use this for initialization

	void Start () {
        initialPosition();

	}
	
	// Update is called once per frame
	void Update () {
        movePlayer();
        fireLaser();
        if(lives <= 0)
        {
            Instantiate(GameOver, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        if(Time.frameCount % 60 == 2)
        {
            createEnemy();
        }
        livesNum.text = lives.ToString();
    }

    private void movePlayer()
    {
        float _horizontalValue = Input.GetAxis("Horizontal");
        float _verticalValue = Input.GetAxis("Vertical");
        _playerPosition = new Vector3(_horizontalValue, _verticalValue, 0);
        gameObject.transform.Translate(_playerPosition * Time.deltaTime * _speed);

        if(transform.position.y > 0)
        {
            transform.position = new Vector3(transform.position.x, 0f, 5);
        }
        if (transform.position.x > 22)
        {
            transform.position = new Vector3(22f, transform.position.y, 5);
        }
        if (transform.position.x < -22)
        {
            transform.position = new Vector3(-22f,transform.position.y, 5);
        }
        if (transform.position.y < -8)
        {
            transform.position = new Vector3(transform.position.x, -8f, 5);
        }

    }
    private void fireLaser()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(FireObject, transform.position, Quaternion.identity);
        }
    }

    private void initialPosition()
    {
        transform.position = new Vector3(0, -3.53f, 5);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            lives = lives - 1;
        }
    }
    
   private void createEnemy()
    {
        Instantiate(Enemyprefab, new Vector3(Random.Range(-21,21),11,5), Quaternion.identity);
    }
}
