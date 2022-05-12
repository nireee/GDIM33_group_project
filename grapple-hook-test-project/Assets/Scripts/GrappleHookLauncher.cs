using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleHookLauncher : MonoBehaviour
{
    public static GrappleHookLauncher _instance;

    [SerializeField]
    private Transform _launcher;

    [SerializeField]
    private float _launchForce; // change to be dependent on distance of player from the mouse

    [SerializeField]
    private GameObject _grappleHookPrefab;

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

            _hookLanded = false;

            GameObject hook = Instantiate(_grappleHookPrefab, _launcher.position, _launcher.rotation);

            Rigidbody2D rb2D = hook.GetComponent<Rigidbody2D>();
            rb2D.AddForce(_launcher.right * _launchForce);
        }
    }

    public void AddLink(Link newLink)
    {
        _links.Add(newLink);
    }

    private void ResetGrappleHook()
    {
        for (int i = 0; i < _links.Count; i++)
        {
            _links[i].Reset();
        }

        _links = new List<Link>();
    }
}
