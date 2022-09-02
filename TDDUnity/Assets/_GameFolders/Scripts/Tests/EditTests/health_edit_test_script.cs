using NUnit.Framework;
using UnityEngine;
using NSubstitute;
using TDDUnity.Abstracts.Combats;
using TDDUnity.Combats;
using TDDUnity.Abstracts.ScriptableObjects;

namespace Combats
{
    public class health_edit_test_script
    {
        IAttacker _attacker;

        [SetUp]
        public void SetUp()
        {
            _attacker = Substitute.For<IAttacker>();
        }

        private IHealth GetHealth(int maxHealth)
        {
            IStats stats = Substitute.For<IStats>();
            stats.MaxHealth.Returns(maxHealth);

            return new Health(stats: stats);
        }

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(5)]
        public void take_damage_(int damageValue)
        {

            #region Arrange: Get Reference what we will use
            int maxHealth = 1;
            IHealth health = GetHealth(maxHealth:maxHealth);
           
            #endregion
            #region Act: Use references we defined in Arrange
            _attacker.Damage.Returns(damageValue);

            health.TakeDamage(attacker: _attacker);

            #endregion

            #region Assert: Get Result

            Assert.AreNotEqual(expected: maxHealth, actual: health.CurrentHealth);

            #endregion
        }
        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(5)]
        public void take_damage_until_health_is_zero(int damageValue)
        {

            #region Arrange: Get Reference what we will use
            int maxHealth = 1;
            IHealth health =GetHealth(maxHealth: maxHealth);
           
            #endregion
            #region Act: Use references we defined in Arrange
            _attacker.Damage.Returns(damageValue);
            health.TakeDamage(attacker: _attacker);

            #endregion

            #region Assert: Get Result

            Assert.GreaterOrEqual(arg1: 0, arg2:health.CurrentHealth);

            #endregion
        }

        [Test]
        public void take_damage_and_trigger_on_health_event()
        {

            #region Arrange: Get Reference what we will use
            int maxHealth = 1;
            IHealth health = GetHealth(maxHealth: maxHealth);
           
            #endregion
            #region Act: Use references we defined in Arrange

            _attacker.Damage.Returns(1);

            string message = string.Empty;

            health.OnTakeDamage += () => message = "OnTakeDamage event triggered";

            health.TakeDamage(attacker: _attacker);

            #endregion

            #region Assert: Get Result

            Assert.AreNotEqual(expected: string.Empty, actual: message);

            #endregion
        }
        [Test]
        [TestCase(2)]
        [TestCase(5)]
        public void take_damage_and_trigger_on_health_event_until_health_is_zero(int damageValue)
        {

            #region Arrange: Get Reference what we will use
            int maxHealth = 11;
            IHealth health  = GetHealth(maxHealth: maxHealth);
           
            #endregion
            #region Act: Use references we defined in Arrange

            _attacker.Damage.Returns(damageValue);
            health.OnTakeDamage += () => damageValue++;


            while (health.CurrentHealth > 0)
            {
                health.TakeDamage(attacker: _attacker);
                Debug.Log("health => " + health.CurrentHealth);

            }

            #endregion

            #region Assert: Get Result

            Assert.GreaterOrEqual(arg1: 0, arg2: health.CurrentHealth);

            #endregion
        }
        [Test]
        public void take__fatal_damage_and_trigger_on_dead_event()
        {

            #region Arrange: Get Reference what we will use
            int maxHealth = 100;
            IHealth health = GetHealth(maxHealth: maxHealth);
           
            #endregion
            #region Act: Use references we defined in Arrange

            _attacker.Damage.Returns(maxHealth+1);

            string message = string.Empty;

            health.OnDead += () => message = "OnDead event triggered";

            health.TakeDamage(attacker: _attacker);

            #endregion

            #region Assert: Get Result

            Assert.AreNotEqual(expected: string.Empty, actual: message);

            #endregion
        }
    }
}
