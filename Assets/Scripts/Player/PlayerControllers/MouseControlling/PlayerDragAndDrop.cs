using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDragAndDrop : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _currentSprite;

    private RotatablePlatform _dragableObject;
    private SizeChangablePlatform _sizeChangablePlatform;
    private Camera _mainCamera;
    private Vector3 _offset;

    private float _maxDistance = 2000f;
    [SerializeField] private LayerMask _paramsLayerNames;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        Initialize();
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        Cleanup();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Initialize();
    }

    private void Initialize()
    {
        _mainCamera = Camera.main;
    }

    private void Cleanup()
    {
        _currentSprite = null;
        _dragableObject = null;
        _sizeChangablePlatform = null;
        _mainCamera = null;
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
        if (_mainCamera == null)
        {
            Debug.LogWarning("Main camera is missing or has been destroyed.");
            return;
        }

        RaycastHit2D hit = Physics2D.Raycast(_mainCamera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, _maxDistance, _paramsLayerNames);

        if (hit.collider != null)
        {
            _currentSprite = hit.collider.GetComponent<SpriteRenderer>();
            _dragableObject = hit.collider.GetComponent<RotatablePlatform>();
            _sizeChangablePlatform = hit.collider.GetComponent<SizeChangablePlatform>();

            if (_currentSprite != null && (_dragableObject == null || !_dragableObject.IsPlayerOnObject) && (_sizeChangablePlatform == null || !_sizeChangablePlatform.IsPlayerOnObject))
            {
                _offset = _currentSprite.transform.position - _mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -_mainCamera.transform.position.z));

                if (_dragableObject != null)
                {
                    _dragableObject.StartManipulation();
                }
                else if (_sizeChangablePlatform != null)
                {
                    _sizeChangablePlatform.StartManipulation();
                }
            }
            else
            {
                _currentSprite = null;
                _dragableObject = null;
                _sizeChangablePlatform = null;
            }
        }
    }

    private void DragAndDropObject()
    {
        if (_currentSprite == null) return;

        if (_mainCamera == null)
        {
            Debug.LogWarning("Main camera is missing or has been destroyed.");
            return;
        }

        Vector3 mouseWorldPos = _mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -_mainCamera.transform.position.z));
        _currentSprite.transform.position = mouseWorldPos + _offset;
    }

    private void Drop()
    {
        if (_dragableObject != null)
        {
            _dragableObject.StopManipulation();
        }

        if (_sizeChangablePlatform != null)
        {
            _sizeChangablePlatform.StopManipulation();
        }

        _currentSprite = null;
        _dragableObject = null;
        _sizeChangablePlatform = null;
    }
}
