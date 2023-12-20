using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : Interactable
{
    [SerializeField] GameObject _door;
    [SerializeField] GameObject _leverOpen;
    [SerializeField] GameObject _leverClosed;
    bool _doorOpen = false;
    protected override void Interaction()
    {
        if (!_doorOpen)
        {
            Destroy(_door);
            AudioSource.PlayClipAtPoint(keysound, gameObject.transform.position);
            _leverOpen.SetActive(true);
            _leverClosed.SetActive(false);
            _doorOpen = true;
        }
        
    }
}
