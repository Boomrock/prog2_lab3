using System;
using System.Collections.Generic;
using System.Text;

namespace prog2_lab3.Interfeses
{
    interface ITransport
    {
        float Cost { get; set; }

        string Path { get; set; }
    }
}
