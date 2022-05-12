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

    protected Rigidbody2D _rigidbody;

    private void Start()
    {
        _player = GameObject.FindWithTag("Player");

        _launcher = GameObject.FindWithTag("Launcher").GetComponent<Transform>();

        _sprite = GetComponent<SpriteRenderer>();

        _rigidbody = GetComponent<Rigidbody2D>();

        GrappleHookLauncher._instance.AddLink(this);


    }

    private void FixedUpdate() // maybe change to Update
    {
        if (_belowLink != null)
            return;

        if (GrappleHookLauncher._instance._hookLanded || (GrappleHookLauncher._instance._links.Count >= GrappleHookLauncher._instance._maxRopeLinks))
        {
            _belowLink = _player;

            HingeJoint2D playerhg2D = _player.GetComponent<HingeJoint2D>();
            playerhg2D.connectedBody = _rigidbody;
            playerhg2D.connectedAnchor = new Vector2(-2, 0);
        }
        else if ((GrappleHookLauncher._instance._links.Count < GrappleHookLauncher._instance._maxRopeLinks) && Vector3.Distance(transform.position, _launcher.position) >= _sprite.bounds.size.x)
        {
            GameObject newRopeLink = Instantiate(_ropeLinkPrefab, _launcher.position, transform.rotation);

            Link link = newRopeLink.GetComponent<Link>();

            
            // setting each rope link's variables to appropriate gameObjects
            _belowLink = newRopeLink;
            link._aboveLink = gameObject;


            // setting up hinge joints
            HingeJoint2D hg = newRopeLink.GetComponent<HingeJoint2D>();
            hg.connectedBody = _rigidbody;
            hg.connectedAnchor = new Vector2(-1, 0);
        }
    }

    public void Reset()
    {
        Destroy(gameObject);
    }
}
