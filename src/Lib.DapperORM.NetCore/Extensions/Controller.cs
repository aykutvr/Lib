using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

public partial class Controller
{
    public Lib.DapperORM.Repositories.IDapperConnectRepository DapperCon { get; set; }
}
