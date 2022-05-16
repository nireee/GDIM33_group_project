using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Link : MonoBehaviour
{
    public GameObject _aboveLink;

    public GameObject _belowLink;

    [SerializeField]
    private GameObject _ropeLinkPrefab;

    private GameObject _player;

    private Transform _launcher;

    private SpriteRenderer _sprite;

    public Rigidbody2D _rigidbody;

    private void Start()
    {
        _player = GameObject.FindWithTag("Player");

        _launcher = GameObject.FindWithTag("Launcher").GetComponent<Transform>();

        _sprite = GetComponent<SpriteRenderer>();

        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (_belowLink != null)
            return;

        if (GrappleHookLauncher._instance._hookLanded || (GrappleHookLauncher._instance._links.Count >= GrappleHookLauncher._instance._maxRopeLinks))
        {
            _belowLink = _player;

            HingeJoint2D playerhg2D = _player.GetComponent<HingeJoint2D>();
            playerhg2D.enabled = true;
            playerhg2D.connectedBody = _rigidbody;
            playerhg2D.connectedAnchor = new Vector2(-2, 0);
        }
        else if ((GrappleHookLauncher._instance._links.Count < GrappleHookLauncher._instance._maxRopeLinks) && Vector3.Distance(transform.position, _launcher.position) >= _sprite.bounds.size.x)
        {
            GrappleHookLauncher._instance.AddLink(this);
        }
    }

    public void Reset()
    {
        Destroy(gameObject);
    }
}
