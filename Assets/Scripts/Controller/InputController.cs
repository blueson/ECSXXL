using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    InputContext _inputContext;

    private float _timer = 0;
    private float _offsetX = 0;
    private float _offsetY = 0;
    private Vector2 _clickPos;

    // Start is called before the first frame update
    void Start()
    {
        _inputContext = Contexts.sharedInstance.input;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 100);
            if (hit.collider != null)
            {
                _clickPos = hit.transform.localPosition;
                _inputContext.ReplaceGameClick((int)_clickPos.x, (int)_clickPos.y);
            }
            _timer = 0;
            _offsetX = 0;
            _offsetY = 0;
        }

        if(Input.GetMouseButton(0))
        { 
            if(_timer < 0.5f)
            {
                _timer += Time.deltaTime;
                _offsetX += Input.GetAxis("Mouse X");
                _offsetY += Input.GetAxis("Mouse Y");
            }
            else
            {
                Slied();
            }
        }

        if(Input.GetMouseButtonUp(0) && _timer < 0.5f && _timer > 0.1f)
        {
            Slied();
        }
    }

    private void Slied()
    {
        SliedDirection dir = Mathf.Abs(_offsetX) > Mathf.Abs(_offsetY)
            ? _offsetX > 0 ? SliedDirection.RIGHT : SliedDirection.LEFT
            : _offsetY > 0 ? SliedDirection.UP : SliedDirection.DOWN;

        _inputContext.ReplaceSlied(new CustomVector2((int)_clickPos.x, (int)_clickPos.y), dir);
    }
}
