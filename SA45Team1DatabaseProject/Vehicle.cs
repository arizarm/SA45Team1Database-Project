using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA45Team1DatabaseProject
{
    class Vehicle
    {
        private string Model, PlateNo, Colour, EngineNo, Status;

        public string model
        {
            get { return Model; }
            set { Model = value; }
        }

        public string plateNo
        {
            get { return PlateNo; }
            set { PlateNo = value; }
        }
        public string colour
        {
            get { return Colour; }
            set { Colour = value; }
        }

        public string engineNo
        {
            get { return EngineNo; }
            set { EngineNo = value; }
        }

        public string status
        {
            get { return Status; }
            set { Status = value; }
        }


    }
}
