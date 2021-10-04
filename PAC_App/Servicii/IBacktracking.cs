using System;
using System.Collections.Generic;
using System.Text;

namespace PAC_App.Servicii
{
    interface IBacktracking<T> where T : IComparable<T> 
    {
        void tipar();
        bool valid(int k);
        bool solutie(int k);
        void back(int k);
    }
}
