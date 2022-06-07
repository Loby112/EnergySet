using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyLib {
    public static class EnergyConverter {
        public static double ToJoule(double calorie){
            return Math.Round(calorie * 4.2, 2);
        }

        public static double ToCalorie(double joule){
            return Math.Round(joule / 4.2, 2);
        }
    }
}
