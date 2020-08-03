using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    [SerializeField]
    GameObject _ztargetCamera;
    [SerializeField]
    GameObject _thirdPersonCamera;

    Cinemachine.CinemachineVirtualCamera _ztarget;
    Cinemachine.CinemachineFreeLook _thirdPerson;
    private int i = 0;
    private GameObject[] _enemies;

    // Start is called before the first frame update
    void Start()
    {
        _ztarget = _ztargetCamera.GetComponent<Cinemachine.CinemachineVirtualCamera>();
        _thirdPerson = _thirdPersonCamera.GetComponent<Cinemachine.CinemachineFreeLook>();
    }

    // Update is called once per frame
    void Update()
    {
        if( GameObject.FindGameObjectsWithTag("enemy").Length == 0)
        {
            _thirdPerson.Priority = 10;
            _ztarget.Priority = 1;
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            int temp = _thirdPerson.Priority;
            _thirdPerson.Priority = _ztarget.Priority;
            _ztarget.Priority = temp;
        }
       if(_thirdPerson.Priority < _ztarget.Priority && Input.GetKeyDown(KeyCode.LeftShift))
            {
            


            _enemies = GameObject.FindGameObjectsWithTag("enemy");
            i++;
            if (i >= _enemies.Length)
            {
                i = 0;
            }

            _ztarget.LookAt = _enemies[i].transform;



            }
            

            
           
        }
    }

