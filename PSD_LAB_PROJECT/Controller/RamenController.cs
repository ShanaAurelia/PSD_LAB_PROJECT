﻿using PSD_LAB_PROJECT.Handler;
using PSD_LAB_PROJECT.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSD_LAB_PROJECT.Controller
{
    public class RamenController
    {
        public static string validateRamenRegistry(string name, string meat, string broth, string price)
        {
            if (name.Equals(null) || name.Equals("") || meat.Equals(null) || meat.Equals("") 
                || broth.Equals(null) || broth.Equals("") || price.Equals("") || 
                price.Equals(null))
            {
                return "Please fill all the required fields";
            }
            else if (!name.Contains("Ramen"))
            {
                return "Ramen name has to have `Ramen` on it!";
            }
            else if (int.Parse(price) < 3000)
            {
                return "Ramen price has to be higher than 3000!";
            }
            Meat ramenMeat = RamenHandler.GetMeatId(meat);
            if(ramenMeat == null)
            {
                return "Error!";
            }
            RamenHandler.CreateRamenHandler(name, ramenMeat.Id, broth, price);
            return "success!";
        }

        public static List<RamenOutput> getRamenData()
        {
            return RamenHandler.getRamenData();
        }
    }
}