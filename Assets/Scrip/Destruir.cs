using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruir : MonoBehaviour
{

    public void DestruirObjeto()
    {
        Destroy(transform.parent.gameObject);
        Destroy(gameObject);
    }
}
