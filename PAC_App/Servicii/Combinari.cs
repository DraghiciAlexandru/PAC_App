using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace PAC_App.Servicii
{
    class Combinari<T> : IBacktracking<T> where T : IComparable<T> 
    {
        protected Lista<T> lista;
        protected T[] s;
        protected int m;
        public Lista<Lista<T>> solutii;

        public Combinari(Lista<T> lista, int m)
        {
            this.m = m;
            s = new T[lista.size()];
            solutii = new Lista<Lista<T>>();
            this.lista = lista;
        }

        public virtual void tipar()
        {
            Lista<T> sol = new Lista<T>();
            for (int i = 0; i < m; i++)
            {
                sol.addFinish(s[i]);
                //Write(s[i].ToString() + " ");
            }
            solutii.addFinish(sol);
            //WriteLine();
        }

        public virtual bool valid(int k)
        {
            for (int i = 0; i < k; i++) 
            {
                if (s[i].CompareTo(s[i + 1]) == 1 || s[i].Equals(s[i + 1]))   
                {
                    return false;
                }
            }
            return true;
        }

        public virtual bool solutie(int k)
        {
            if (k == (m - 1)) 
            {
                return true;
            }
            return false;
        }

        public virtual void back(int k)
        {
            for (int i = 0; i < lista.size(); i++) 
            {
                s[k] = lista.getAtPosition(i);
                if (valid(k))
                {
                    if (solutie(k))
                    {
                        tipar();
                    }
                    else
                    {
                        back(k + 1);
                    }
                }
            }
        }
    }
}
