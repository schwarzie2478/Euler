using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem44
{
    internal class PentagonalGenerator
    {
        private List<long> _list = new List<long>();
        public PentagonalGenerator()
        {
            _list.Add(0);
        }

        internal long GetPentagonalNumber(int v)
        {
            if (_list.Count > v)
            {
                return _list[v];
            }

            GenerateMore(v);
            return _list[v];
        }

        private void GenerateMore(int v)
        {
            //Generate the missing inbetween
            foreach (var item in Enumerable.Range(_list.Count, v - _list.Count + 1))
            {
                _list.Add((3 * item - 1) * item / 2);
            }
        }

        internal bool IsPentagonalNumber(long n)
        {
            while (_list.Last<long>() < n)
            {
                GetPentagonalNumber(_list.Count + 100);
            }
            return _list.Contains(n);
        }
        internal long GetDifference(int p1, int p2)
        {
            if(_list.Count <= p2)
            {
                GenerateMore(p2);
            }
            return _list[p2]-_list[p1];

        }
    }
}