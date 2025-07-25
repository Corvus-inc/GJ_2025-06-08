using Effects;
using Game.Interactions;
using Game.MiniGames;
using UnityEngine;

namespace Game.Levels
{
    public class LevelManager
    {
        private readonly LevelsConfig _config;
        private readonly InteractionSystem _interactionSystem;
        private readonly MiniGameCoordinator _miniGameCoordinator;
        private GameObject _currentLevel;
        private int _currentIndex;
        private EffectAccumulatorView _effectAccumulatorView;

        //public static int MyLevelIndex => _currentIndex;
        public int CurrentLevelIndex => _currentIndex;
        public RoomView CurrentRoomView { get; private set; }

        public LevelManager(LevelsConfig config,
            InteractionSystem interactionSystem,
            MiniGameCoordinator miniGameCoordinator)
        {
            _config = config;
            _interactionSystem = interactionSystem;
            _miniGameCoordinator = miniGameCoordinator;
            _currentIndex = -1;
        }

        /// <summary>
        /// Загружает уровень по индексу из LevelsConfig.
        /// </summary>
        public void LoadLevel(int index, Transform parent, EffectAccumulatorView effectAccumulatorView = null)
        {
            if (effectAccumulatorView != null)
            {
                _effectAccumulatorView = effectAccumulatorView;
            }
            // Убираем старый уровень
            if (_currentLevel != null)
            {
                _interactionSystem.ClearAll();   // очищает все собранные коллекции
                _miniGameCoordinator.UnregisterAll();
                Object.Destroy(_currentLevel);
            }

            // Загружаем новый
            _currentIndex = index;


            var prefab = _config.levels[index].levelPrefab;
            _currentLevel = Object.Instantiate(prefab, parent);
            CurrentRoomView = _currentLevel.GetComponentInChildren<RoomView>();

            // Регистрируем взаимодействия и мини-игры
            _interactionSystem.AddNewInteractionCollection(CurrentRoomView);
            _miniGameCoordinator.SetLevel(index);
            _miniGameCoordinator.RegisterGames(_currentLevel.transform, _effectAccumulatorView);
           
        }

        /// <summary>
        /// Загружает следующий уровень, если он есть
        /// </summary>
        public bool LoadNextLevel(Transform parent)
        {
            int next = _currentIndex + 1;
            if (next < _config.levels.Length)
            {
                LoadLevel(next, parent);
                return true;
            }
            return false;
        }
    }
}