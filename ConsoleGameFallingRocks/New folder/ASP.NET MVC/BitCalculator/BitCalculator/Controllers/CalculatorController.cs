using BitCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BitCalculator.Controllers
{
    public class CalculatorController : Controller
    {
       
            public List<Unit> unitList;
            public CalculatorController()
            {
                this.unitList = new List<Unit>() 
                {
                    new Unit("bit"),
                    new Unit("Byte"),
                    new Unit("Kilobit"),
                    new Unit("Kilobyte"),
                    new Unit("Megabit"),
                    new Unit("Megabyte"),
                    new Unit("Gigabit"),
                    new Unit("Gigabyte"),
                    new Unit("Terabit"),
                    new Unit("Terabyte"),
                    new Unit("Petabit"),
                    new Unit("Petabyte"),
                    new Unit("Exabit"),
                    new Unit("Exabyte"),
                    new Unit("Zettabit"),
                    new Unit("Zettabyte"),
                    new Unit("Yottabit"),
                    new Unit("Yottabyte"),
                };
            }
        

        public ActionResult Index()
        {
            return View(unitList);
        }

        [HttpPost]
        public ActionResult Calculate(string types, int count, int kilo)
        {
            var currentValueIndex = Array.IndexOf(unitList.Select(x => x.Name).ToArray(), types);

            unitList[currentValueIndex].Value = 1d * count;
            int currentValueLength = unitList[currentValueIndex].Name.Length;

            int biteValue = 0;
            int byteValue = 0;
            if (unitList[currentValueIndex].Name[currentValueLength - 1] == 'b')
            {
                biteValue = kilo == 1000 ? 125 : 128;
                byteValue = 8;

                if (currentValueIndex - 1 >= 0)
                {
                    for (int i = currentValueIndex - 1; i >= 0; i--)
                    {
                        if (i + 1 < unitList.Count())
                        {
                            int valueLength = unitList[i].Name.Length;

                            if (unitList[i].Name[valueLength - 1] == 'b')
                            {
                                unitList[i].Value = unitList[i + 1].Value * byteValue;
                            }
                            else
                            {
                                unitList[i].Value = unitList[i + 1].Value * biteValue;
                            }

                        }
                    }
                }
                if (currentValueIndex + 1 <= unitList.Count)
                {
                    for (int i = currentValueIndex + 1; i < unitList.Count; i++)
                    {
                        if (i - 1 >= 0)
                        {
                            int valueLength = unitList[i].Name.Length;

                            if (unitList[i].Name[valueLength - 1] == 'b')
                            {
                                unitList[i].Value = unitList[i - 1].Value / biteValue;
                            }
                            else
                            {
                                unitList[i].Value = unitList[i - 1].Value / byteValue;
                            }

                        }
                    }
                }
            }
            else
            {
                biteValue = 8;
                byteValue = kilo;

                if (currentValueIndex - 1 >= 0)
                {
                    for (int i = currentValueIndex - 1; i >= 0; i--)
                    {
                        if (currentValueIndex + 1 <= unitList.Count())
                        {
                            int valueLength = unitList[i].Name.Length;

                            if (unitList[i].Name[valueLength - 1] == 'b')
                            {
                                unitList[i].Value = unitList[i + 1].Value * biteValue;
                            }
                            else
                            {
                                unitList[i].Value = unitList[i + 2].Value * byteValue;
                            }

                        }
                    }
                }
                if (currentValueIndex + 1 <= unitList.Count)
                {
                    for (int i = currentValueIndex + 1; i < unitList.Count; i++)
                    {
                        if (i - 1 >= 0)
                        {
                            int valueLength = unitList[i].Name.Length;

                            if (unitList[i].Name[valueLength - 1] == 'b')
                            {
                                unitList[i].Value = unitList[i - 2].Value / byteValue;
                            }
                            else
                            {
                                unitList[i].Value = unitList[i - 1].Value / biteValue;
                            }

                        }
                    }
                }
            }

            ViewBag.Message = kilo;
            return View("Index", unitList);
        }
    }
}