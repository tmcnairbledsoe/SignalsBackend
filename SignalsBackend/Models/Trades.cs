﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalsBackend.Models
{
    public class Trades : List<Trade>
    {
        public static Trades Empty { get; } = new Trades();
    }
}