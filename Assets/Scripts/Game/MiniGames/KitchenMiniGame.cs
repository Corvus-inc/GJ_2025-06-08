using System;
using Game.Quests;
using UnityEngine;

using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace Game.MiniGames
{
    public class KitchenMiniGame : IMiniGame
    {
        private BaseTimingMiniGame _miniGameController;
        private readonly GameObject _miniGameObj;
        public QuestType QType { get; } = QuestType.Kitchen;
        public event Action<QuestType> OnMiniGameComplete;
        public event Action<QuestType> OnMiniGameStart;

        public KitchenMiniGame()
        {
            _miniGameObj = Object.Instantiate(Resources.Load<GameObject>("Prefabs/MiniGame/MiniGameManager1"));
            if (_miniGameObj != null)
            {  
                _miniGameController = _miniGameObj.GetComponent<CookingMiniGame>();
            }

        }

        public void OnActionButtonClick()
        {
            throw new NotImplementedException();
        }

        public void StartGame()
        {
            Debug.Log("Kitchen Mini Game Started");
            OnMiniGameComplete?.Invoke(QType);
            if (_miniGameController == null)
            {
                if (_miniGameObj != null)
                {
                    _miniGameController = _miniGameObj.GetComponent<CookingMiniGame>();
                    //_miniGameController = FindObjectOfType<MiniGameController>();
                }
            }

            if (_miniGameController != null)
            {
                Debug.Log("? MiniGameController ������! ������ ����-����...");

                // ������������� ��������� ��� ������ ��������� ����� ��������
                var panel = _miniGameController.Panel;
                if (panel != null && panel.activeInHierarchy)
                {
                    Debug.Log("?? ������ ���� ��������, ��������� � ����� ��������");
                    panel.SetActive(false);
                }

                // ����������� �� ������� ����-����
                _miniGameController.OnMiniGameComplete += OnMiniGameCompleted;
                // (_miniGameController as FlowerMiniGameInherited ) += OnWateringAttempt;

                // ��������� ����-���� (������ ��������� �������������)
                _miniGameController.StartMiniGame();
            }
            else
            {
                Debug.LogError("? MiniGameController �� ������! ������� ��� ������ �������� �� MiniGameManager � ������� �������.");
            }
        }

        private void OnMiniGameCompleted()
        {
            Debug.Log("����-���� ���������!");

            OnMiniGameComplete?.Invoke(QType);

            // ���������� �� ������� ����� �������� ������ ������
            if (_miniGameController != null)
            {
                _miniGameController.OnMiniGameComplete -= OnMiniGameCompleted;
                // _miniGameController.OnWateringAttempt -= OnWateringAttempt;
            }

            // ����� ����� �������� ������ ����������:
            // - ���� ������� ������
            // - �������� �������� ����� ������
            // - �������� ��������� ������ � �������
            // - ��������� ��������

        }

        public void ForceEndMiniGame()
        {
            if (_miniGameController != null && _miniGameController.gameObject.activeSelf)
            {
                _miniGameController.EndMiniGame();
            }
        }
    }
}