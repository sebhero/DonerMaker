using System;
using System.Reflection;

namespace upg1_b
{
    //DÖner
    internal class Doner
    {
        private Bread _breadType;
        private int _falafels;
        private bool _feta;
        private bool _majs;
        private int _meatGrams;
        private bool _sallad;
        private Sauce _sauceType;
        private bool _saurerkraut;
        private bool _tomatoAndCucumber;

        /// <summary>
        /// Creates the Döner by querying the hungry customer for content.
        /// </summary>
        /// <returns></returns>
        public Doner OrderDoner()
        {
            Console.WriteLine("What do you want with your Döner?");

            _meatGrams = int.Parse(Ask("How much meat (grams): "));
            if (_meatGrams == 0)
            {
                _falafels = int.Parse(Ask("So no meat..\n How about falafels (amount): "));
            }

            switch (Ask("Sallad (y/n): "))
            {
                case "y":
                    _sallad = true;
                    break;
                case "n":
                    _sallad = false;
                    break;
                default:
                    _sallad = false;
                    break;
            }
            _tomatoAndCucumber = (bool) Ask("Tomato and Cucumbers (y/n): ", AskType.YesNo);
            _majs = (bool) Ask("Majs (y/n): ", AskType.YesNo);
            _saurerkraut = (bool) Ask("Sauerkraut (y/n): ", AskType.YesNo);
            _feta = (bool) Ask("feta (y/n): ", AskType.YesNo);

            _sauceType = (Sauce) Ask("what type of sauce (CHILI,GARLIC,TZASIKI,ROTWEISSE): ", AskType.Sauce);
            _breadType = (Bread) Ask("what type of bread(durum/pita): ", AskType.Bread);
            return this;
        }

        /// <summary>
        ///     Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        ///     A string that represents the current object.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return "meat: " + _meatGrams + "\nfalafel: " + _falafels + "\ntomato and cucumber: " + _tomatoAndCucumber +
                   "\nsalad: " + _sallad + "\nmajs: " + _majs + "\nsaurerkruat: " + _saurerkraut + "\nfeta: " + _feta +
                   "\nsauce: " +
                   _sauceType.ToString() + "\nbread: " + _breadType;
        }

        /// <summary>
        /// Simple user question selector. returns a object of the result.
        /// </summary>
        /// <param name="question"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        private Object Ask(string question, AskType type)
        {
            string answear = Ask(question);
            switch (type)
            {
                case AskType.YesNo:
                    if (answear == "y")
                        return true;
                    if (answear == "n")
                        return false;
                    break;

                case AskType.Sauce:
                    return Enum.Parse(typeof (Sauce), answear, true);
                case AskType.Bread:
                    return Enum.Parse(typeof (Bread), answear, true);
                default:
                    return answear;
            }
            return answear;
        }

        /// <summary>
        /// puts the döner togheter and prints it out to the user.
        /// </summary>
        public void MakeDoner()
        {
            PrintPluses(30);
            Console.WriteLine("Baking the {0} bread",_breadType);
            if(_sallad)
            { Console.WriteLine("Adding sallad to the bread"); }
            if(_tomatoAndCucumber)
            {Console.WriteLine("adding tomatoes and cucumber");}
            if(_majs)
            { Console.WriteLine("adding majs"); }
            if (_feta)
            { Console.WriteLine("adding fetta cheese"); }
            if (_saurerkraut)
            { Console.WriteLine("adding sauerkraut"); }
            if (_meatGrams>0)
            { Console.WriteLine("adding {0} grams of meat",_meatGrams); }
            else
            {
                 Console.WriteLine("adding {0} falafels", _falafels); 
            }
            Console.WriteLine("putting the {0} sauce over the content",_sauceType);
            Console.WriteLine("Serving the customer");
            PrintPluses(30);
            Console.WriteLine("The döner is done and served!");
            Console.ReadKey();
        }

        /// <summary>
        /// Prints out pluses. for gui.
        /// </summary>
        /// <param name="count"></param>
        private void PrintPluses(int count)
        {
            
            Console.WriteLine(new String('*', count));

        }


        /// <summary>
        /// simple input reader
        /// </summary>
        /// <param name="question"></param>
        /// <returns></returns>
        private string Ask(string question)
        {
            string input;
            Console.Write(question);
            try
            {
                input = Console.ReadLine();
                if (input == "")
                {
                    return Ask(question);
                }
            }
            catch (Exception e)
            {
                Console.Error.WriteLine("error occured: " + e.Message);
                return Ask(question);
            }
            return input;
        }

        /// <summary>
        /// Dummy object creator. for testing.
        /// </summary>
        public void DummyDoner()
        {
            _breadType = Bread.Durum;
            _falafels = 0;
            _feta = true;
            _majs = false;
            _meatGrams = 10;
            _sallad = true;
            _sauceType = Sauce.RotWeisse;
            _saurerkraut = false;
            _tomatoAndCucumber = true;
        }
    }

    internal enum AskType
    {
        YesNo,
        Sauce,
        Bread
    }

    internal enum Bread
    {
        Durum,
        Pita
    }

    internal enum Sauce
    {
        Chili,
        Garlic,
        Tzasiki,
        RotWeisse
    }
}