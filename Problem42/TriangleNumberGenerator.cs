using System;
using System.Collections.Generic;

namespace Problem42
{
    internal class TriangleNumberGenerator
    {
        private int _upperLimit = 100;
        public TriangleNumberGenerator(int upperLimit)
        {
            _upperLimit = upperLimit;
        }

        internal IEnumerable<int> Next()
        {
            int n = 1;
            int triangleNumber = n;
            yield return triangleNumber;
            while (n < _upperLimit)
            {
                triangleNumber = n * (n + 1) / 2;
                yield return triangleNumber;
                n++;
            }
        }
    }
}