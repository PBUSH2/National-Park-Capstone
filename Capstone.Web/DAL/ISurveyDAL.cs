﻿using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.DAL
{
    public interface ISurveyDAL
    {
        bool SaveSurvey(Survey newSurvey);
        string FindTopPark();
    }

}