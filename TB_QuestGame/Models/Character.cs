using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    /// <summary>
    /// base class for the player and all game characters
    /// </summary>
    public class Character
    {
        #region ENUMERABLES

        public enum StartingItem
        {
            None,
            HealthPack,
			Towel,
			Potato,
			BrokenPhone
        }

        #endregion

        #region FIELDS

        private string _name;
        private int _age;
		private StartingItem _startingItem;

        #endregion

        #region PROPERTIES

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

		public StartingItem startingItem
        {
            get { return _startingItem; }
            set { _startingItem = value; }
        }

        #endregion

        #region CONSTRUCTORS

        public Character()
        {

        }

		public Character(string name, StartingItem race)
        {
            _name = name;
			_startingItem = startingItem;
        }

        #endregion

        #region METHODS



        #endregion
    }
}
