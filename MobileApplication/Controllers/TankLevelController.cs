using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MobileApplication.Models;
using MobileApplication.Models.DataLayer;



namespace MobileApplication.Controllers
{
    public class ListTankEntry
    {
        public string TankName { get; set; }
        public string Tank
        {
            get;
            set;
        }
    }

    public class ListTankGroupEntry
    {
        public string TankGroup { get; set; }
        public string Group
        {
            get;
            set;
        }
    }

    public class ListProductEntry
    {
        public string Product { get; set; }
        public string ProductName
        {
            get;
            set;
        }
    }
        public class TankLevelController : Controller
        {
            
            public ActionResult Index()
            {
                return View();
            }

            public ActionResult EnterTankData()
            {
                
                var TankGroup = new[] {
                new ListTankGroupEntry { TankGroup = "A", Group = "A" },
                new ListTankGroupEntry { TankGroup = "B", Group = "B" },  
                new ListTankGroupEntry { TankGroup = "C", Group = "C" },
                new ListTankGroupEntry { TankGroup = "D", Group = "D" },
                new ListTankGroupEntry { TankGroup = "E", Group = "E" },  
                new ListTankGroupEntry { TankGroup = "F", Group = "F" }
                                };
                ViewBag.TankGroups = new SelectList(TankGroup, "TankGroup", "Group");

                var TankNames = new[] {
                new ListTankEntry { TankName = "1", Tank = "1" },
                new ListTankEntry { TankName = "2", Tank = "2" },  
                new ListTankEntry { TankName = "3", Tank = "3" },
                new ListTankEntry { TankName = "4", Tank = "4" },
                new ListTankEntry { TankName = "5", Tank = "5" },  
                new ListTankEntry { TankName = "6", Tank = "6" },
                new ListTankEntry { TankName = "7", Tank = "7" },
                new ListTankEntry { TankName = "8", Tank = "8" },  
                new ListTankEntry { TankName = "9", Tank = "9" },
                new ListTankEntry { TankName = "10", Tank = "10" },
                new ListTankEntry { TankName = "11", Tank = "11" },  
                new ListTankEntry { TankName = "12", Tank = "12" }
                                };
                ViewBag.TankNames = new SelectList(TankNames, "TankName", "Tank");

                var Products = new[] {
                new ListProductEntry { Product = "C11", ProductName = "C11" },
                new ListProductEntry { Product = "C11B", ProductName = "C11B" },  
                new ListProductEntry {Product = "C13", ProductName = "C13"},
                new ListProductEntry { Product = "C14", ProductName = "C14" },
                new ListProductEntry {Product = "C15", ProductName = "C15"},  
                new ListProductEntry{ Product = "C27A", ProductName = "C27A"},
                new ListProductEntry { Product = "C27B", ProductName = "C27B" },
                new ListProductEntry { Product = "C41", ProductName = "C41" },  
                new ListProductEntry { Product = "C47", ProductName = "C47" },
                new ListProductEntry {Product = "C52", ProductName = "C52"},
                new ListProductEntry {Product = "C53", ProductName = "C53" },  
                new ListProductEntry {Product = "C54", ProductName = "C54" }
                                };
                ViewBag.Products = new SelectList(Products, "Product", "ProductName");
                

                return View();
            }
            [HttpPost]
            public ActionResult EnterTankData(TankData1 td, string TankGroup)
            {
                MobileEntities TankLevelData = new MobileEntities();
                string sTankName = TankGroup + td.TankName;

                TankLevelData.funcAddTankData(sTankName, td.Product, td.TanlLevel, td.Unavailable, td.MaxBlendPercentage, td.Comments);
                return View("UpdateTankData");
            }
            public ActionResult ViewTankData()
            {
                MobileEntities TankLevelData = new MobileEntities();
                var listData = TankLevelData.TankData1.AsQueryable();
                return View(listData);
            }

            public ViewResult UpdateTankDataStatus()
            {
                CTankData objTankData = new CTankData();
                objTankData.TankNumber = Request.Form["TankNumber"].ToString();
                objTankData.Product = Request.Form["Product"].ToString();
                objTankData.Level = Convert.ToDouble(Request.Form["TankLevel"].ToString());
                objTankData.Unavailable = false;     // Convert.ToBoolean(Request.Form["Unavailable"]);
                objTankData.Comment = Request.Form["Comment"].ToString();
                objTankData.MaxBlendPercentage = 0.45;
                // connect to database and update the record; if successful display result
                return View(objTankData);

            }

        }
    }

