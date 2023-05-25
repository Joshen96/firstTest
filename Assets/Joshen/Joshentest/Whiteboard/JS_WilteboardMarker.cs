using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class JS_WilteboardMarker : MonoBehaviour
{

    [SerializeField] private Transform _tip;
    [SerializeField] private int _penSize = 5;

    private Renderer _renderer;
    private Color[] _colors;
    private float _tipHeight;


    private RaycastHit _touch;
    private JS_WhiteBoard _whiteboard;
    private Vector2 _touchPos;
    private bool _touchedLastFrame;
    private Vector2 _lastTouchPos;

    private Quaternion _lastTouchRot;


    
    // Start is called before the first frame update
    void Start()
    {
        _renderer = _tip.GetComponent<Renderer>();
        _colors = Enumerable.Repeat(_renderer.material.color, _penSize * _penSize).ToArray();
        _tipHeight = _tip.localScale.y;

    }
    

    // Update is called once per frame
    void Update()
    {

        Draw();
    }
    public void colorchange()
    {
        _renderer = _tip.GetComponent<Renderer>();
        _colors = Enumerable.Repeat(_renderer.material.color, _penSize * _penSize).ToArray();
        _tipHeight = _tip.localScale.y;
    }
    private void Draw() //그림그리는 함수
    {
        if(Physics.Raycast(_tip.position,transform.up,out _touch,_tipHeight)) //펜의 레이캐스트
        {
            if(_touch.transform.CompareTag("Whiteboard"))  //레이의 트랜스폼이 칠판태그일경우
            {
                if(_whiteboard == null)
                {
                    _whiteboard = _touch.transform.GetComponent<JS_WhiteBoard>();
                }

                _touchPos = new Vector2(_touch.textureCoord.x, _touch.textureCoord.y);

                var x = (int)(_touchPos.x * _whiteboard.textureSize.x - (_penSize / 2));
                var y = (int)(_touchPos.y * _whiteboard.textureSize.y - (_penSize / 2));


                if (y < 0 || y > _whiteboard.textureSize.y || x < 0 || x > _whiteboard.textureSize.x) return;

                if(_touchedLastFrame)
                {
                    _whiteboard.texture.SetPixels(x, y, _penSize, _penSize, _colors);

                    for(float f = 0.01f; f<1.00f; f+=0.03f) //부드럽게 그리기
                    {
                        var lerpX = (int)Mathf.Lerp(_lastTouchPos.x, x, f);
                        var lerpY = (int)Mathf.Lerp(_lastTouchPos.y, y, f);
                        _whiteboard.texture.SetPixels(lerpX, lerpY, _penSize, _penSize, _colors);
                    }

                    transform.rotation = _lastTouchRot;
                    _whiteboard.texture.Apply(); //그림적용


                }
                _lastTouchPos = new Vector2(x, y);
                _lastTouchRot = transform.rotation;
                _touchedLastFrame = true;
                return;

            }
        }

        _whiteboard = null;
        _touchedLastFrame = false;
    }
}
