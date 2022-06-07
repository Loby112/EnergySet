using System;

namespace EnergyLib {
    public class EnergyData {
        private int _id;
        private string _energyMetric;
        private double _value;

        public string EnergyMetric{
            get => _energyMetric;
            set{
                if (value != "Calorie" && value != "Joule")
                    throw new ArgumentException("String has to be either Calorie or Joule");
                _energyMetric = value;
            }
        }

        public double Value{
            get => _value;
            set => _value = value;
        }

        public int Id{
            get => _id;
            set => _id = value;
        }

    }
}
