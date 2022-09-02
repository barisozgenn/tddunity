using System.Collections;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using TDDUnity.Abstracts.Controllers;
using TDDUnity.Controllers;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace Combats
{
    public class player_health_play_mode_test_script
    {
        //IPlayerController _playerController;
        //IEnemyController _enemyController;

        private IEnumerator LoadSceneTestScene()
        {
            yield return SceneManager.LoadSceneAsync("CombatTestScene");
        }

        [UnitySetUp]
        IEnumerator Setup()
        {
            yield return LoadSceneTestScene();

            //_playerController = GameObject.FindObjectOfType<PlayerController>();
            //_enemyController = GameObject.FindObjectOfType<EnemyController>();
           
        }

        [UnityTest]
        public IEnumerator player_take_damage()
        {

            #region Arrange: Get Reference what we will use
            var player = GameObject.FindObjectOfType<PlayerController>();
            var enemy = GameObject.FindObjectOfType<EnemyController>();

            int startHealth = player.Health.CurrentHealth;

            #endregion
            #region Act: Use references we defined in Arrange

            yield return new WaitForSeconds(3f);

            enemy.transform.position = player.transform.position;

            yield return new WaitForSeconds(3f);
            #endregion

            #region Assert: Get Result


            Assert.AreEqual(expected: startHealth-1, actual: player.Health.CurrentHealth);

            yield return null;
            #endregion
          
        }
    }

}
