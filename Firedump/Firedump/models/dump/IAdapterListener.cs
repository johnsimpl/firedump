﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.models.dump
{
    interface IAdapterListener
    {
        void onTableStartDump(string table);
     
    }
}