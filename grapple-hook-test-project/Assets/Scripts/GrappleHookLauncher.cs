using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleHookLauncher : MonoBehaviour
{
    public static GrappleHookLauncher _instance;

    [SerializeField]
    private HingeJoint2D _playerhg2D;

    [SerializeField]
    private Transform _launcher;

    [SerializeField]
    private float _launchForce; // change to be dependent on distance of player from the mouse

    [SerializeField]
    private GameObject _grappleHookPrefab;

    [SerializeField]
    private GameObject _ropeLinkPrefab;

    public List<Link> _links = new List<Link>();

    public int _maxRopeLinks;

    public bool _hookLanded = false;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            ResetGrappleHook();

            GameObject hook = Instantiate(_grappleHookPrefab, _launcher.position, _launcher.rotation);

            Rigidbody2D rb2D = hook.GetComponent<Rigidbody2D>();
            rb2D.AddForce(_launcher.right * _launchForce);

            _links.Add(hook.GetComponent<Link>());
        }
        else if (Input.GetButtonDown("Fire2"))
        {
            ResetGrappleHook();
        }
    }

    public void AddLink(Link prevLink)
    {
        GameObject newRopeLinkGO = Instantiate(_ropeLinkPrefab, _launcher.position, prevLink.gameObject.transform.rotation);

        Link newLink = newRopeLinkGO.GetComponent<Link>();

        // setting each rope link's variables to appropriate gameObjects
        prevLink._belowLink = newRopeLinkGO;
        newLink._aboveLink = prevLink.gameObject;

        // setting up hinge joints
        HingeJoint2D hg = newRopeLinkGO.GetComponent<HingeJoint2D>();
        hg.connectedBody = prevLink._rigidbody;
        hg.connectedAnchor = new Vector2(-1, 0);

        _links.Add(newLink);
    }

    public void Climb()
    {
        if (_links.Count <= 1)
            return;

        if (!_hookLanded)
            return;

        Destroy(_links[_links.Count - 1].gameObject);

        _links.RemoveAt(_links.Count - 1);
    }

    public void Descend()
    {
        if (_links.Count >= _maxRopeLinks)
            return;

        if (!_hookLanded)
            return;

        AddLink(_links[_links.Count - 1]);
    }

    private void ResetGrappleHook()
    {
        for (int i = 0; i < _links.Count; i++)
        {
            _links[i].Reset();
        }

        _links = new List<Link>();

        _playerhg2D.enabled = false;

        _hookLanded = false;
    }
}
