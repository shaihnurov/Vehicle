using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Money
{
    internal class Vehicle
    {
        public int id { get; set; }
        public string carName, carFirm, carYear, carStreght, carCase, carCountry;

        public string CarName
        {
            get { return carName; }
            set { carName = value; }
        }
        public string CarFirm
        {
            get { return carFirm; }
            set { carFirm = value; }
        }
        public string CarYear
        {
            get { return carYear; }
            set { carYear = value; }
        }
        public string CarStreght
        {
            get { return carStreght; }
            set { carStreght = value; }
        }
        public string CarCase
        {
            get { return carCase; }
            set { carCase = value; }
        }
        public string CarCountry
        {
            get { return carCountry; }
            set { carCountry = value; }
        }

        public Vehicle() { }

        public Vehicle(string carName, string carFirm, string carYear, string carStreght, string carCase, string carCountry)
        {
            CarName = carName;
            CarFirm = carFirm;
            CarYear = carYear;
            CarStreght = carStreght;
            CarCase = carCase;
            CarCountry = carCountry;
        }
    }
}
