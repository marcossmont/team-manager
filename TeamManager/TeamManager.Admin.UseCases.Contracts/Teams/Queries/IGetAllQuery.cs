﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TeamManager.Admin.UseCases.Contracts.Teams.Queries
{
    public interface IGetAllQuery
    {
        GetAllQueryResult Query();
    }
}