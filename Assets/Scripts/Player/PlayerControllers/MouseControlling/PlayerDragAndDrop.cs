using UnityEngine;

public class PlayerDragAndDrop : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _currentSprite;
    private DragableObject _dragableObject;
    private Camera _mainCamera;
    private Vector3 _offset;

    private float _maxDistance = 2000f;
    [SerializeField] private LayerMask _paramsLayerNames;

    private void Start()
    {
        _mainCamera = Camera.main;
    }

    private void Update()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
            SelectPart();

        if (Input.GetMouseButtonUp(0))
            Drop();
#endif

        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
                SelectPart();

            if (touch.phase == TouchPhase.Ended)
                Drop();
        }

        DragAndDropObject();
    }

    private void SelectPart()
    {
        RaycastHit2D hit = Physics2D.Raycast(_mainCamera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, _maxDistance, _paramsLayerNames);

        if (hit.collider != null)
        {
            _currentSprite = hit.collider.GetComponent<SpriteRenderer>();
            _dragableObject = hit.collider.GetComponent<DragableObject>();

            if (_currentSprite != null && (_dragableObject == null || !_dragableObject.IsPlayerOnObject))
            {
                _offset = _currentSprite.transform.position - _mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -_mainCamera.transform.position.z));
            }
            else
            {
                _currentSprite = null;
                _dragableObject = null;
            }
        }
    }

    private void DragAndDropObject()
    {
        if (_currentSprite == null) return;

        Vector3 mouseWorldPos = _mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -_mainCamera.transform.position.z));
        _currentSprite.transform.position = mouseWorldPos + _offset;
    }

    private void Drop()
    {
        _currentSprite = null;
        _dragableObject = null;
    }
}
