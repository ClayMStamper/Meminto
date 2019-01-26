using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    [SerializeField] private Transform _player;
    [SerializeField] private float _lerpSpeed = 1f;
    [SerializeField] private Vector3 _offset;
    
    void Update() {
        transform.position = Vector3.Lerp(transform.position, _player.position + _offset, Time.deltaTime * _lerpSpeed);
    }

    [ContextMenu("Bake Offset")]
    private void BakeOffset() {
        _offset = transform.position - _player.transform.position;
    }
    
}
