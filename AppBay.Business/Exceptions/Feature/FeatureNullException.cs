using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBay.Business.Exceptions.Feature
{
    public class FeatureNullException : Exception
    {

        public FeatureNullException() : base("Feature should not be null")
        {
            
        }
        public FeatureNullException(string message) : base (message)
        {
            
        }
    }
}
