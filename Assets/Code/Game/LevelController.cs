using UnityEngine;
using static Game.LevelData;

namespace Game
{
    public sealed class LevelController : MonoBehaviour
    {
        [SerializeField] private LevelData _levelData;
        [SerializeField] private Transform _brickMain;
        [SerializeField] private Brick _brickPrefab;
        [SerializeField] private float _brickDistance = 1.25f;

        private LineData[] _lineData;
        private Brick[] _bricks;
        private Paddle _paddle;
        private Ball _ball;
        private float _lineDistance = -0.4f;

        private void Awake()
        {
            _levelData.GetData(out _lineData);
            GenerateLevel();
        }

        private void Start()
        {
            _paddle = GetComponentInChildren<Paddle>();
            _ball = GetComponentInChildren<Ball>();
        }

        private void GenerateLevel()
        {
            for (int y = 0; y < _lineData.Length; y++)
            {
                for (int x = 0; x < _lineData[y]._bricksQuantity; x++)
                {
                    Brick brick = Instantiate(_brickPrefab, _brickMain.position + new Vector3(x * _brickDistance, y * _lineDistance, 0), _brickMain.rotation, _brickMain);
                    brick.SetColor(_lineData[y]._color);
                }
            }
        }

        private void DestroyLevel()
        {
            _bricks = _brickMain.GetComponentsInChildren<Brick>(true);
            for (int i = 0; i < _bricks.Length; i++)
            {
                Destroy(_bricks[i].gameObject);
            }
        }

        public void CheckBricks()
        {
            _bricks = _brickMain.GetComponentsInChildren<Brick>(true);
            if (_bricks.Length <= 1)
            {
                ResetLevel();
            }
        }

        public void ResetLevel()
        {
            _ball.Reset();
            _paddle.Reset();
            DestroyLevel();
            GenerateLevel();
        }
    }
}