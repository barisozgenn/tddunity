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
        IPlayerController _player;
        IEnemyController _enemy;

        private IEnumerator LoadSceneTestScene()
        {
            yield return SceneManager.LoadSceneAsync("CombatTestScene");
        }

        [UnitySetUp]
        IEnumerator Setup()
        {
            yield return LoadSceneTestScene();

            _player = GameObject.FindObjectOfType<PlayerController>();
            _enemy = GameObject.FindObjectOfType<EnemyController>();
           
        }

        [UnityTest]
        public IEnumerator player_take_damage_in_single_time()
        {

            #region Arrange: Get Reference what we will use

            int startHealth = _player.Health.CurrentHealth;

            #endregion
            #region Act: Use references we defined in Arrange

            yield return new WaitForSeconds(3f);

            _enemy.transform.position = _player.transform.position;

            yield return new WaitForSeconds(3f);
            #endregion

            #region Assert: Get Result


            Assert.AreEqual(expected: startHealth-1, actual: _player.Health.CurrentHealth);

            yield return null;
            #endregion
          
        }
        [UnityTest]
        [TestCase(2, ExpectedResult = (IEnumerator)null)]
        [TestCase(10, ExpectedResult = (IEnumerator)null)]
        public IEnumerator player_take_some_damage_in_single_time(int damageValue)
        {

            #region Arrange: Get Reference what we will use

            int startHealth = _player.Health.CurrentHealth;

            #endregion
            #region Act: Use references we defined in Arrange

            yield return new WaitForSeconds(3f);

            _enemy.transform.position = _player.transform.position;

            yield return new WaitForSeconds(3f);
            #endregion

            #region Assert: Get Result


            Assert.AreEqual(expected: startHealth - damageValue, actual: _player.Health.CurrentHealth);

            yield return null;
            #endregion

        }
    }

}
