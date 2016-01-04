using System;

namespace upg1
{
    internal class Product
    {
        private const double FoodVatRate = 0.12, OtherVatRate = 0.25;
        private int _count;
        private bool _isFood;
        private string _name;
        private double _totalNetValue;
        private double _totalVat;
        private double _unitPrice;

        public void Start()
        {
            //reads the inputs
            ReadInputs();

            //Calculate tot tax
            CalculateValues();

            //Print calculations.
            PrintReceipt();
        }

        /// <summary>
        /// Prints out the receipt
        /// </summary>
        private void PrintReceipt()
        {
            PrintPluses(15);
            Console.Write("   Sebastians store   ");
            PrintPluses(10);
            Console.WriteLine();
            PrintPluses(3);
            Console.WriteLine();
            PrintPluses(3);
            Console.Write("  Name of the Product\t\t {0}", _name);
            Console.WriteLine();
            PrintPluses(3);
            Console.Write("  Quantity\t\t\t\t " + _count);
            Console.WriteLine();
            PrintPluses(3);
            Console.Write("  Unit price\t\t\t\t " + _unitPrice);
            Console.WriteLine();
            PrintPluses(3);
            Console.Write("  Food Item\t\t\t\t " + _isFood);
            Console.WriteLine();
            PrintPluses(3);
            Console.WriteLine();
            PrintPluses(3);
            Console.Write("  Total amount to pay\t\t " + _totalNetValue);
            Console.WriteLine();
            PrintPluses(3);
            Console.Write("  Including VAT\t\t\t " + _totalVat);
            Console.WriteLine();
            PrintPluses(48);
            Console.WriteLine("\n\n");
        }

        /// <summary>
        /// Prints out pluses. used for gui
        /// </summary>
        /// <param name="howMany"></param>
        private static void PrintPluses(int howMany)
        {
            for (int i = 0; i < howMany; i++)
            {
                Console.Write("+");
            }
        }

        /// <summary>
        /// Calcs the result
        /// </summary>
        private void CalculateValues()
        {
            double totCost = _totalNetValue = _count*_unitPrice;
            if (_isFood)
            {
                _totalVat = FoodVatRate*totCost;
                _totalNetValue = totCost + _totalVat;
            }
            else
            {
                _totalVat = OtherVatRate*totCost;
                _totalNetValue = totCost + _totalVat;
            }
        }

        /// <summary>
        /// Reads the inputs from user
        /// </summary>
        private void ReadInputs()
        {
            _name = ReadName();

            _unitPrice = ReadNetUnitPrice();
            _isFood = ReadIfFood();
            _count = ReadCount();
        }

        /// <summary>
        /// input count
        /// </summary>
        /// <returns></returns>
        private int ReadCount()
        {
            try
            {
                return int.Parse(Ask("How many: "));
            }
            catch (Exception e)
            {
                Console.Error.WriteLine("error occured: " + e.Message);
                return ReadCount();
            }
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
            return String.Format("name: {0}, price: {1}, isFood: {2}, count: {3}", _name, _unitPrice, _isFood,
                                 _count);
        }

        private bool ReadIfFood()
        {
            try
            {
                switch (Ask("Food item (y/n): "))
                {
                    case "y":
                        return true;
                    case "n":
                        return false;

                    default:
                        return ReadIfFood();
                }
            }
            catch (Exception e)
            {
                Console.Error.WriteLine("error occured: " + e.Message);
                return ReadIfFood();
            }
        }

        /// <summary>
        /// gets the net unit price
        /// </summary>
        /// <returns></returns>
        private double ReadNetUnitPrice()
        {
            try
            {
                return _unitPrice = Double.Parse(Ask("Enter the price: "));
            }
            catch (Exception e)
            {
                Console.Error.WriteLine("error occured: " + e.Message);
                return ReadNetUnitPrice();
            }
        }

        /// <summary>
        /// gets name of product
        /// </summary>
        /// <returns></returns>
        private string ReadName()
        {
            return Ask("Enter the name of the product: ");
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
    }
}