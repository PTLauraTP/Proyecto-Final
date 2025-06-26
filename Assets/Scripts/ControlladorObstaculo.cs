using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;

public class ControlladorObstaculo : MonoBehaviour
{
    [SerializeField] Rigidbody _miCuerpo;
    [SerializeField] float limiteIz;
    [SerializeField] Transform target;
    [SerializeField] float negativo = -1f;
    [SerializeField] float velocidad;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, target.position)>=2f)
        {
            Debug.Log("hola");
            _miCuerpo.velocity = new Vector3(velocidad * Time.deltaTime * negativo, 0f, 0f);
        }
        else
        {
            target.position = new Vector3(target.position.x * negativo,target.position.y, target.position.z);
            negativo *= negativo;
        }
        
    }
}
