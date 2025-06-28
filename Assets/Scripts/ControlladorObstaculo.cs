using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;

public class ControlladorObstaculo : MonoBehaviour
{
    [SerializeField] Rigidbody _miCuerpo;
    [SerializeField] float limiteIz;
    [SerializeField] float limiteX = 12.5f;
    [SerializeField] float negativo = -1f;
    [SerializeField] float minVel;
    [SerializeField] float maxVel;
    [SerializeField] float velocidad;
    [SerializeField] Vector3 target;
    bool comprobador = false;
    // Start is called before the first frame update
    void Start()
    {
        velocidad = Random.Range(minVel, maxVel);
        
 
            negativo = Random.Range(1,2) ==1 ? -1:1; 
            limiteX *= negativo;
      
           
        target = new Vector3(limiteX, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, target) > 0.25f && comprobador ==false)
        {
            comprobador=true;
            _miCuerpo.velocity = new Vector3(velocidad * Time.deltaTime * negativo, 0f, 0f);
        }
        else
        {

            comprobador = false;

            negativo *= -1;
            limiteX *= negativo;

            _miCuerpo.velocity = new Vector3(velocidad * 4 * Time.deltaTime * negativo, 0f, 0f);
            target = new Vector3(limiteX, transform.position.y, transform.position.z);
        }
    }
}
