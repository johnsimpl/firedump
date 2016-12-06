﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.models.location
{
    interface ILocationManagerListener
    {
        void setSaveProgress(int progress);
        void onSaveInit(int maxprogress);
        void onSaveComplete(List<LocationResultSet> results);
        void onSaveError(string message);
        void onInnerSaveInit(string location);
    }
}