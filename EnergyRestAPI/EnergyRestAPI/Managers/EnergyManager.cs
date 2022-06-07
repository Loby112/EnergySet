using System.Collections.Generic;
using System.Linq.Expressions;
using EnergyLib;

namespace EnergyRestAPI.Managers {
    public class EnergyManager{
        private static int nextId = 1;

        private static List<EnergyData> energyData = new List<EnergyData>(){
            new EnergyData(){Id = nextId++, EnergyMetric = "Calorie", Value = 500},
            new EnergyData(){Id = nextId++, EnergyMetric = "Calorie", Value = 46},
            new EnergyData(){Id = nextId++, EnergyMetric = "Joule", Value = 900},
            new EnergyData(){Id = nextId++, EnergyMetric = "Calorie", Value = 432},
            new EnergyData(){Id = nextId++, EnergyMetric = "Joule", Value = 500},
        };

        public IEnumerable<EnergyData> GetAll(string sort){
            List<EnergyData> TempData = new List<EnergyData>();
            foreach (var item in energyData){
                TempData.Add(new EnergyData{
                    Id = item.Id,
                    EnergyMetric = item.EnergyMetric,
                    Value = item.Value,
                });
            }

            if (sort == "Joule"){
                foreach (var e in TempData) {
                    if (e.EnergyMetric == "Calorie"){
                        e.Value = EnergyConverter.ToJoule(e.Value);
                        e.EnergyMetric = "Joule";
                    }
                }
                return TempData;
            }

            if (sort == "Calorie"){
                foreach (var e in TempData) {
                    if (e.EnergyMetric == "Joule"){
                        e.Value = EnergyConverter.ToCalorie(e.Value);
                        e.EnergyMetric = "Calorie";
                    }
                }

                return TempData;
            }

            return energyData;
        }

        public EnergyData AddData(EnergyData newData){
            newData.Id = nextId++;
            energyData.Add(newData);
            return newData;
        }
    }
}
