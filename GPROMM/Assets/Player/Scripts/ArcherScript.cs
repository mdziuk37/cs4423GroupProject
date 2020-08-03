using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherScript : MonoBehaviour
{
    [SerializeField]
    Animator archerAnim;
    [SerializeField]
    GameObject _arrow;

    [SerializeField]
    GameObject bow;

    bool _trackarrow = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(archerAnim.GetCurrentAnimatorStateInfo(0).IsTag("lAttack") && _trackarrow == false)
        {
            print("has caught it");
            GameObject arrowTemp;

            arrowTemp = Instantiate(_arrow,new Vector3(bow.transform.position.x, bow.transform.position.y +1.5f, bow.transform.position.z), bow.transform.rotation);
            arrowTemp.transform.Rotate(0, -90, 0);
            //arrowTemp.GetComponent<Rigidbody>().velocity = 35 * transform.localScale.x * arrowTemp.transform.forward;
            _trackarrow = true;
            StartCoroutine(wait());
            Destroy(arrowTemp, 4);
        }
       
    }

    IEnumerator wait()
    {
       yield return new WaitForSeconds(1f);
        _trackarrow = false;
    }

}
