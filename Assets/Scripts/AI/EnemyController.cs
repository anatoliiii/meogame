using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    // public LineRenderer _line;
    public InfoBar _infoBar;
    public Transform _firePoint;
    public float speed = 20f;
    float direction ;
    private Rigidbody2D _rigidbody;

    private void Start() {
        _rigidbody = GetComponent<Rigidbody2D>();
        _infoBar = GetComponent<InfoBar>();
        direction = transform.localScale.x;
    }

    private void Update() {
        StartCoroutine(Shoot());
       
        _rigidbody.velocity = new Vector2 ( speed * direction, _rigidbody.velocity.y);
        transform.localScale = new Vector3(direction,transform.localScale.y,transform.localScale.z);
    }

    IEnumerator Shoot() {
        RaycastHit2D _hit = Physics2D.Raycast(_firePoint.position, _firePoint.right);
        if (_hit) {
            Debug.Log(_hit.transform.name);
            Character character = _hit.transform.GetComponent<Character>();
            if (character != null ) {
                _infoBar.Heart--;
            }
            // _line.SetPosition(0,_firePoint.position);
            // _line.SetPosition(1,_hit.point);
        }
        // else {
            // _line.SetPosition(0,_firePoint.position);
            // _line.SetPosition(1,_firePoint.position + _firePoint.position*100);
        // }
        // _line.enabled = true;
        yield return new WaitForSeconds(5f);
        // _line.enabled = false;
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Wall") direction *= -1;
    }
}
