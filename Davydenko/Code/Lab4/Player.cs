﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    public class Player
    {
        private string _name;
        private int _points;

        public string Name { get => _name; set => _name = value; }
        public int Points { get => _points; set => _points = value; }
    }
}
