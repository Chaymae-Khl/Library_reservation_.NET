﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace MyLibraryService
{
    [ServiceContract]
    internal interface test
    {
        [OperationContract]
        void getdata();
    }
}
